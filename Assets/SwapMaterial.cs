using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    public Material desiredMaterial;
    public bool swapped{get; private set;}

    public void Swap() {
        if (swapped)
            return;

        this.GetComponent<MeshRenderer>().material = desiredMaterial;
        swapped = true;
    }
}
