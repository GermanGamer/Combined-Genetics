using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalScreen : MonoBehaviour
{
    public InputField inputField;
    public GameObject[] screens;



    public void OnEditStop()
    {
        if (inputField.text == "shop")
        {
            screens[0].SetActive(true);
            screens[1].SetActive(false);
        }
        else
        {
            screens[1].SetActive(true);
            screens[0].SetActive(false);
        }
    }
}
