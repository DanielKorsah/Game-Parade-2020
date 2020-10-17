using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeVisualiser : MonoBehaviour
{
    [SerializeField] private Image arrow;
    [SerializeField] private TMP_Text timeText;
    private bool rotated = false;
    private float targetRotation = 0;



    void Start()
    {
        CharacterInfo.TimeAdvanceEvent.AddListener(AdvanceClock);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AdvanceClock()
    {
        LeanTween.rotate(arrow.rectTransform, -180, 0.5f);
        timeText.text = CharacterInfo.Time == 0 ? "Time Left: 2" : "Time Left: 1";
    }
}
