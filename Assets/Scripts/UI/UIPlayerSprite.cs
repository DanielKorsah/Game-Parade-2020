using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerSprite : MonoBehaviour
{
    Image i;

    void Start()
    {
        i = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        i.sprite = CharacterInfo.PlayerSprite;
    }
}
