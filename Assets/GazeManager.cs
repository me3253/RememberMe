using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public LayerMask gazeReceivingMask;
    public GameObject student, classWall, book, greenGlobe, blueGlobe, fishTank, characterManager, audioManager, materialManager;

    private GameObject[] fishes = new GameObject[3];
    private CharacterManager charManager;
    private AudioManager sfx;
    private MaterialManager matManager;
    private new Camera camera;
    private int lookCounter = 0;
    private bool lookAway = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        charManager = characterManager.GetComponent<CharacterManager>();
        sfx = audioManager.GetComponent<AudioManager>();
        matManager = materialManager.GetComponent<MaterialManager>();
        fishes[0] = fishTank.GetNamedChild("Fish");
        fishes[1] = fishTank.GetNamedChild("Fish (1)");
        fishes[2] = fishTank.GetNamedChild("Fish (2)");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (!Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, gazeReceivingMask))
            return;

        // We have hit an object that can receive the raycast

        if (hit.collider.gameObject == classWall && lookCounter < 4) {
            lookAway = false;

            if (lookCounter == 1 && !book.GetComponent<ThrowBook>().thrown) {
                book.GetComponent<ThrowBook>().Throw();
                charManager.HideCharacter("yellow");
                sfx.breathing.Play();
            }
            else if (lookCounter == 2 && !greenGlobe.GetComponent<Rotate>().enableRotation) {
                greenGlobe.GetComponent<Rotate>().enableRotation = true;
                blueGlobe.GetComponent<Rotate>().enableRotation = true;
                foreach (GameObject fish in fishes)
                    fish.GetComponent<MovingFish>().speed = 0.05f;

                charManager.HideCharacter("orange");
                charManager.HideCharacter("pink");
                sfx.clock.Play();
            }
            else if (lookCounter == 3 && !student.GetComponent<LookUp>().neckRaised) {
                student.GetComponent<LookUp>().RaiseNeck();
                charManager.HideCharacter("purple");
                charManager.HideCharacter("teal");
            }
        }
        else if (hit.collider.gameObject == matManager.paper && lookCounter == 4 && !matManager.catPoster.GetComponent<SwapMaterial>().swapped) {
            lookAway = false;
            matManager.catPoster.GetComponent<SwapMaterial>().Swap();
            matManager.mistakePoster.GetComponent<SwapMaterial>().Swap();
            matManager.rulesPoster.GetComponent<SwapMaterial>().Swap();
            matManager.bullyPoster.GetComponent<SwapMaterial>().Swap();
            sfx.horror.Play();
        }

        if (lookAway)
            return;

        if (hit.collider.gameObject == student) {
            print(++lookCounter);

            if (lookCounter == 2 && !sfx.door.isPlaying)
                sfx.door.Play();
            else if (lookCounter == 3 && !sfx.footsteps.isPlaying) {
                charManager.HideCharacter("lilac");
                charManager.HideCharacter("teacher");
                sfx.footsteps.Play();
            }
            else if (lookCounter == 4 && !matManager.paper.GetComponent<SwapMaterial>().swapped) {
                StartCoroutine(AudioFadeOut.FadeOut(sfx.ambience, 1f));
                charManager.HideCharacter("cyan");
                charManager.HideCharacter("hotPink");
                charManager.HideCharacter("lightBlue");
                charManager.HideCharacter("forest");
                matManager.paper.GetComponent<SwapMaterial>().Swap();
            }
            else if (lookCounter == 5) {
                sfx.scream.Play();
            }

            lookAway = true;
        }
    }
}
