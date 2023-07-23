using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{


    public void AddApple()
    {
        GameManager.instance.appleCount++;
    }
}
