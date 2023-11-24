using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadManager : MonoBehaviour
{
    public GameObject orange, pink, hotPink, lightBlue, lilac, forest, cyan, yellow, purple, teal, teacher;

    public void ShowAllHeads() {
        orange.SetActive(true);
        pink.SetActive(true);
        hotPink.SetActive(true);
        lightBlue.SetActive(true);
        lilac.SetActive(true);
        forest.SetActive(true);
        cyan.SetActive(true);
        yellow.SetActive(true);
        teacher.SetActive(true);
        teal.SetActive(true);
        purple.SetActive(true);
    }
}
