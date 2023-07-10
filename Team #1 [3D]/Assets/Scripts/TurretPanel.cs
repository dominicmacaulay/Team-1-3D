using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Diagnostics.Tracing;

public class TurretPanel : MonoBehaviour
{
    public TMP_Text nameSpace;
    int index = 0;
    List<string> nameText = new List<string>()
    {
        "JU5TAB0AT.68",
        "DEACTIVATE.45",
        "NEBULUS.32",
        "REDACTED.57",
        "ADMIRAL.72",
    };
    int lockNumber = 0;
    public GameObject dial;
    int powerLevel;

    void Update()
    {
        nameSpace.text = nameText[index].ToString();

        dial.transform.eulerAngles = new Vector3(0, 0, lockNumber);
    }

    public void OnClickLeftNameButton()
    {
        if (index > 0)
        {
            index -= 1;
        }
    }

    public void OnClickRightNameButton()
    {
        if (index < 4)
        {
            index += 1;
        }
    }

    public void OnClickDialButton()
    {
        lockNumber -= 36;
        if (lockNumber < -360)
        {
            lockNumber = 0;
        }
    }

    public void SliderValue(float value)
    {
        powerLevel = (int)value;
    }

    public void OnClickDeactivateButton()
    {
        if (index == 2 && lockNumber == -252 && powerLevel == 3)
        {
            //deactivate turret
            Debug.Log("deactivate");
        }
    }
}
