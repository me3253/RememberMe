using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ThrowBook : MonoBehaviour
{
    public GameObject chalkboard;

    public bool thrown{get; private set;} = false;

    public void Throw(float speedX, float speedY, float speedZ) {
        this.GetComponent<Rigidbody>().velocity = new Vector3(speedX, speedY, speedZ);
        thrown = true;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == chalkboard)
            this.GetComponent<AudioSource>().Play();
    }
}
