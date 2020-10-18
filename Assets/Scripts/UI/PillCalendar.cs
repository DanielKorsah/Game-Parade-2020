using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PillCalendar : MonoBehaviour
{

    public static UnityEvent DayAdvanceEvent = new UnityEvent();

    [SerializeField] private List<Sprite> daySprites = new List<Sprite>();
    [SerializeField] private Image dayVisualiser;
    [SerializeField] private GameObject Judy;
    [SerializeField] private Transform Bedroom;





    void Start()
    {
        DayAdvanceEvent.AddListener(NewDay);
        dayVisualiser.sprite = daySprites[0];
    }

    void NewDay()
    {
        dayVisualiser.sprite = daySprites[CharacterInfo.Day];
        Judy.gameObject.transform.position = Bedroom.position;
    }

}
