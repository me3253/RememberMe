using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject upperArmR, upperArmL, foreArmL, neck;
    public bool startScare = false;

    public void setPosition() {
        upperArmR.transform.localEulerAngles = new Vector3(120,122,60);
        upperArmL.transform.localEulerAngles = new Vector3(58,17,50);
        foreArmL.transform.localEulerAngles = new Vector3(50,-49,0);
    }

    void Update() {
        if (startScare) {
            neck.transform.Rotate(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
            this.transform.Translate(0, -10*Time.deltaTime, 0);
        }
    }
}
