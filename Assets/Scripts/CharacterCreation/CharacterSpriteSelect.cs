using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterSpriteSelect : MonoBehaviour
{
    public static UnityEvent CharacterSelectForward = new UnityEvent();
    public static UnityEvent CharacterSelectBackwards = new UnityEvent();

    [SerializeField] private List<Sprite> characterSprites = new List<Sprite>();
    private int index;
    private Image imageComponent;


    void Start()
    {
        //add listeners so that later controller support can be added
        CharacterSelectForward.AddListener(ScrollForward);
        CharacterSelectBackwards.AddListener(ScrollBackwards);

        imageComponent = gameObject.GetComponent<Image>();


        index = -1;
        CharacterSelectForward.Invoke();
        CharacterInfo.PlayerSpriteIndex = index;
        imageComponent.sprite = CharacterInfo.Sprites[CharacterInfo.PlayerSpriteIndex];

    }



    public void ScrollForward()
    {
        index++;
        if (index > CharacterInfo.Sprites.Count - 1)
            index = 0;

        CharacterInfo.PlayerSpriteIndex = index;
        imageComponent.sprite = CharacterInfo.Sprites[CharacterInfo.PlayerSpriteIndex];
    }

    public void ScrollBackwards()
    {
        index--;
        if (index < 0)
            index = CharacterInfo.Sprites.Count - 1;

        CharacterInfo.PlayerSpriteIndex = index;
        imageComponent.sprite = CharacterInfo.Sprites[CharacterInfo.PlayerSpriteIndex];
    }
}
