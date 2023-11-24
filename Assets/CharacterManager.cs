using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject orange, pink, hotPink, lightBlue, lilac, forest, cyan, yellow, purple, teal, teacher;

    public void HideCharacter(string name) {
        string checkName = name.ToLower();
        
        switch (checkName) {
            case "yellow":
                yellow.SetActive(false);
                break;
            case "orange":
                orange.SetActive(false);
                break;
            case "pink":
                pink.SetActive(false);
                break;
            case "lilac":
                lilac.SetActive(false);
                break;
            case "teacher":
                teacher.SetActive(false);
                break;
            case "purple":
                purple.SetActive(false);
                break;
            case "teal":
                teal.SetActive(false);
                break;
            case "cyan":
                cyan.SetActive(false);
                break;
            case "hotpink":
                hotPink.SetActive(false);
                break;
            case "lightblue":
                lightBlue.SetActive(false);
                break;
            case "forest":
                forest.SetActive(false);
                break;
        }
    }
}
