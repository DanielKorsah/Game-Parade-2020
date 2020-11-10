using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSoundEventHandler : MonoBehaviour
{
    public void Cancel()
    {
        SoundManager.ButtonEvent.Invoke();
    }

    public void Confirm()
    {
        SoundManager.ConfirmEvent.Invoke();
        Debug.Log("Confirmed");
    }
}
