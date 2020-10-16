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
        UpdateFill();
    }

    void UpdateNotoriety(int change)
    {
        NotorietyValue += change;
        UpdateFill();
    }

    void UpdateFill()
    {
        NotorietyPercentage = (float)NotorietyValue / MaxValue;
        fillImage.fillAmount = NotorietyPercentage;
        label.text = "Notoriety\n" + System.Math.Round(NotorietyPercentage * 100, 2) + "%";
    }
}
