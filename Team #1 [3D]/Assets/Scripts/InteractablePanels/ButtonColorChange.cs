using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Button button;

    public void ChangeButtonColor(Color wantedColor)
    {
        ColorBlock cb = button.colors;
        //cb.normalColor = wantedColor;
        //cb.highlightedColor = wantedColor;
        cb.pressedColor = wantedColor;
        button.colors = cb;
    }
}
