using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ThrowBook : MonoBehaviour
{
    public GameObject chalkboard;

    public bool thrown{get; private set;} = false;

    public void Throw() {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -50);
        thrown = true;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == chalkboard)
            this.GetComponent<AudioSource>().Play();
    }
}
