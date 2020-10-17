using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInfo : MonoBehaviour
{
    public static List<Sprite> Sprites;
    public static int PlayerSpriteIndex = 1;
    public static int[] Stats = { 1, 1, 1 };
    public static CharacterInfo Instance { get; private set; }
    public static int Notoriety = 0;
    public static int Time = 0;
    public static int Day = 0;

    public static UnityEvent TimeAdvanceEvent = new UnityEvent();

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
        TimeAdvanceEvent.AddListener(AdvanceTime);
    }

    private void AdvanceTime()
    {
        if (Time == 0)
        {
            Time++;
        }
        else
        {
            Day++;
            Time = 0;
        }
    }

}


public enum Stat
{
    Body,
    Mind,
    Charm
}
