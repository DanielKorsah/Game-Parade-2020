using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class NotorietyEvent : UnityEvent<int> { }

public class NotorietyMeter : MonoBehaviour
{
    public static NotorietyEvent NotorietyChange = new NotorietyEvent();
    public int NotorietyValue = 0;
    public int MaxValue = 112;


    private float NotorietyPercentage = 0;
    [SerializeField] private Image fillImage;
    [SerializeField] private TMP_Text label;


    void Start()
    {
        NotorietyChange.AddListener(UpdateNotoriety);
        UpdateNotoriety(0);
    }

    void UpdateNotoriety(int change)
    {
        NotorietyValue += change;
        CharacterInfo.Notoriety = NotorietyValue;
        UpdateFill();
    }

    void UpdateFill()
    {
        NotorietyPercentage = (float)NotorietyValue / MaxValue;
        fillImage.fillAmount = NotorietyPercentage;

        NotorietyPercentage = (float)System.Math.Round(NotorietyPercentage * 100, 2);
        label.text = "Notoriety\n" + NotorietyPercentage + "%";
    }
}
