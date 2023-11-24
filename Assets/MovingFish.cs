using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : MonoBehaviour
{
    public float speed = 0.005f;

    void Update() {        
        if (transform.localRotation.eulerAngles.y == 0) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);

            if (transform.localPosition.z <= -0.44f)
                transform.localRotation = new Quaternion(transform.localRotation.x, 180, transform.localRotation.z, transform.localRotation.w);
        }
        else {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + speed);

            if (transform.localPosition.z >= 0.44f)
                transform.localRotation = new Quaternion(transform.localRotation.x, 0, transform.localRotation.z, transform.localRotation.w);
        }
    }
}
