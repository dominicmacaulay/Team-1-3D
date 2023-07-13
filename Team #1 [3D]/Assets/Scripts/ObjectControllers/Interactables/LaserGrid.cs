using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGrid : MonoBehaviour
{
    public bool isDisabled = false;

    public void DisableGrid()
    {
        gameObject.SetActive(false);
        isDisabled = true;
        Debug.Log(isDisabled);
    }
}
