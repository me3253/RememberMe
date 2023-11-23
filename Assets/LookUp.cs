using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUp : MonoBehaviour
{
    public GameObject neck;

    public bool neckRaised{get; private set;}

    public void RaiseNeck() {
        neck.transform.localEulerAngles = new Vector3(-55, neck.transform.localEulerAngles.y, neck.transform.localEulerAngles.z);
        neckRaised = true;
    }
}
