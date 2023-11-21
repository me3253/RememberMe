using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public LayerMask gazeReceivingMask;
    public GameObject student, chalkboard;

    private new Camera camera;
    private int lookCounter = 0;
    private bool lookAway = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, gazeReceivingMask)) {
            if (hit.collider.gameObject == chalkboard) {
                lookAway = false;

                if (lookCounter == 3)
                    student.GetComponent<LookUp>().RaiseNeck();
            }

            if (lookAway)
                return;

            if (hit.collider.gameObject == student) {
                print(++lookCounter);
                lookAway = true;
            }
        }
    }
}
