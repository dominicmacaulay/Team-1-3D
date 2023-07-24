using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpausePlayerAction : MonoBehaviour
{
    public SUPERCharacterAIO characterController;

    public void OnEnable()
    {
        characterController.UnpausePlayer();
    }
}