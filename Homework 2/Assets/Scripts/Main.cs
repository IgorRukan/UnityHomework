using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{

    public GameObject[] canvas;

    public Button[] buttons;

    public Dropdown dropdown;

    private Text text;

    public void InMenu(int screen)
    {
        canvas[0].SetActive(true);
        canvas[screen].SetActive(false);
    }

    public void InOptions(int screen)
    {
        canvas[0].SetActive(false);
        canvas[screen].SetActive(true);
    }

    public void TextChanges(string message)
    {
        text.text = message;
    }

    public void SetText(Text setText)
    {
        text = setText;
    }

    public void Disable(bool disable)
    {
        foreach (var button in buttons)
        {
            button.interactable=disable;
        }
    }

    public void Dropdown()
    {
        int num = dropdown.value;
        switch (num)
        {
            case 0:
            {
                text.text = "Option A";
                break;
            }
            case 1:
            {
                text.text = "Option B";
                break;
            }
            case 2:
            {
                text.text = "Option C";
                break;
            }
            case 3:
            {
                text.text = "Option D";
                break;
            }
        }
    }
}
