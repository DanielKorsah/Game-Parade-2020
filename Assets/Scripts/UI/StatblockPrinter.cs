using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatblockPrinter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text block = GetComponent<TMP_Text>();
        block.text = string.Format("Body: {0}\nMind: {1}\nCharm: {2}", CharacterInfo.Stats[0], CharacterInfo.Stats[1], CharacterInfo.Stats[2]);
    }

    // Update is called once per frame

}
