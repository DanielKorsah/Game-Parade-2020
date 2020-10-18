using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PillCalendar : MonoBehaviour
{

    public static UnityEvent DayAdvanceEvent = new UnityEvent();

    [SerializeField] private List<Sprite> daySprites = new List<Sprite>();
    [SerializeField] private List<GameObject> tasks = new List<GameObject>();
    [SerializeField] private Image dayVisualiser;
    [SerializeField] private GameObject Judy;
    [SerializeField] private Transform Bedroom;





    void Start()
    {
        foreach (GameObject task in tasks)
        {
            task.SetActive(false);
        }
        DayAdvanceEvent.AddListener(NewDay);
        dayVisualiser.sprite = daySprites[0];
        tasks[0].SetActive(true);

    }

    void NewDay()
    {
        dayVisualiser.sprite = daySprites[CharacterInfo.Day];
        Judy.gameObject.transform.position = Bedroom.position;

        tasks[CharacterInfo.Day - 1].SetActive(false);
        tasks[CharacterInfo.Day].SetActive(true);

    }

}
