using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayerAction : MonoBehaviour
{
    public SUPERCharacterAIO characterController;

    public void OnEnable()
    {
        characterController.PausePlayer();
    }
}