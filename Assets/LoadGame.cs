using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene("Classroom");
    }
}
