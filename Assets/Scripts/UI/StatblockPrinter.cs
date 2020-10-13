using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class StatblockPrinter : MonoBehaviour
{
    public static UnityEvent UpdateStatsUI = new UnityEvent();
    void Start()
    {
        UpdateStatsUI.AddListener(ForceUpdate);
        ForceUpdate();
    }

    public void ForceUpdate()
    {
        TMP_Text block = GetComponent<TMP_Text>();
        block.text = string.Format("Body: {0}\nMind: {1}\nCharm: {2}", CharacterInfo.Stats[0], CharacterInfo.Stats[1], CharacterInfo.Stats[2]);
    }

}
