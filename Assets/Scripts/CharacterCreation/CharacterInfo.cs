using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public static List<Sprite> Sprites;
    public static int PlayerSpriteIndex = 1;
    public static int[] Stats = { 1, 1, 1 };
    public static CharacterInfo Instance { get; private set; }

    void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Sprites = new List<Sprite>() { Resources.Load<Sprite>("Art/CharacterArt/judyCC_1"), Resources.Load<Sprite>("Art/CharacterArt/judyCC_2"), Resources.Load<Sprite>("Art/CharacterArt/judyCC_3") };
    }

}

public enum Stat
{
    Body,
    Mind,
    Charm
}
