using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public LayerMask gazeReceivingMask;
    public GameObject student, classWall;

    private new Camera camera;
    private AudioSource ambience;
    private int lookCounter = 0;
    private bool lookAway = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        ambience = this.GetComponent<AudioSource>();
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

            if (lookCounter == 3)
                student.GetComponent<LookUp>().RaiseNeck();
        }

        if (lookAway)
            return;

        if (hit.collider.gameObject == student) {
            print(++lookCounter);

            if (lookCounter == 4)
                StartCoroutine(AudioFadeOut.FadeOut(ambience, 1f));

            lookAway = true;
        }
    }
}
