using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerSprite : MonoBehaviour
{
    //private List<Sprite> sprites = new List<Sprite>() { Resources.Load<Sprite>("Art/CharacterArt/judyStatic_1.png"), Resources.Load<Sprite>("Art/CharacterArt/judyStatic_2.png"), Resources.Load<Sprite>("Art/CharacterArt/judyStatic_3.png") };
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = CharacterInfo.Sprites[CharacterInfo.PlayerSpriteIndex];
    }
}
