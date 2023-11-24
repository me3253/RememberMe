using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool enableRotation = false;

    void Update ()
    {
        if (enableRotation)
            transform.Rotate (0,180*Time.deltaTime,0);
    }
}
