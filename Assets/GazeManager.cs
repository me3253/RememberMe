using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public LayerMask gazeReceivingMask;
    public GameObject student, classWall, book, greenGlobe, blueGlobe, fishTank, catPoster, mistakePoster, rulesPoster, bullyPoster, characterManager;

    private GameObject[] fishes = new GameObject[3];
    private CharacterManager charManager;

    private new Camera camera;
    private AudioSource ambience;
    private int lookCounter = 0;
    private bool lookAway = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        ambience = this.GetComponent<AudioSource>();
        charManager = characterManager.GetComponent<CharacterManager>();
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

        if (hit.collider.gameObject == classWall) {
            lookAway = false;

            if (lookCounter == 1 && !book.GetComponent<ThrowBook>().thrown) {
                book.GetComponent<ThrowBook>().Throw();
                charManager.HideCharacter("yellow");
            }
            else if (lookCounter == 2 && !greenGlobe.GetComponent<Rotate>().enableRotation) {
                greenGlobe.GetComponent<Rotate>().enableRotation = true;
                blueGlobe.GetComponent<Rotate>().enableRotation = true;
                foreach (GameObject fish in fishes)
                    fish.GetComponent<MovingFish>().speed = 0.05f;

                charManager.HideCharacter("orange");
                charManager.HideCharacter("pink");
            }
            else if (lookCounter == 3 && !student.GetComponent<LookUp>().neckRaised) {
                student.GetComponent<LookUp>().RaiseNeck();
                charManager.HideCharacter("purple");
                charManager.HideCharacter("teal");
            }
            else if (lookCounter == 4 && !catPoster.GetComponent<SwapMaterial>().swapped) {
                catPoster.GetComponent<SwapMaterial>().Swap();
                mistakePoster.GetComponent<SwapMaterial>().Swap();
                rulesPoster.GetComponent<SwapMaterial>().Swap();
                bullyPoster.GetComponent<SwapMaterial>().Swap();
            }
        }

        if (lookAway)
            return;

        if (hit.collider.gameObject == student) {
            print(++lookCounter);

            if (lookCounter == 3) {
                charManager.HideCharacter("lilac");
                charManager.HideCharacter("teacher");
            }
            if (lookCounter == 4) {
                StartCoroutine(AudioFadeOut.FadeOut(ambience, 1f));
                charManager.HideCharacter("cyan");
                charManager.HideCharacter("hotPink");
                charManager.HideCharacter("lightBlue");
                charManager.HideCharacter("forest");
            }

            lookAway = true;
        }
    }
}
