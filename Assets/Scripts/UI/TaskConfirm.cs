using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TaskConfirm : MonoBehaviour
{

    [System.Serializable]
    public class TaskInteractedEvent : UnityEvent<string, string, float, int> { };
    public static TaskInteractedEvent TaskInteraction;

    [SerializeField] private TMP_Text tasknameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField]
    private TMP_Text oddsText
    ;
    private PopDown popDown;


    void Start()
    {
        TaskInteraction = new TaskInteractedEvent();
        TaskInteraction.AddListener(PresentBox);
        popDown = gameObject.GetComponent<PopDown>();
    }

    void PresentBox(string title, string desc, float odds, int stat)
    {
        tasknameText.text = title;
        descriptionText.text = desc;
        string statType = "DEFAULT";

        if (stat == 0)
            statType = "Body";
        else if (stat == 1)
            statType = "Mind";
        else if (stat == 2)
            statType = "Charm";

        oddsText.text = statType + "test\n" + odds + "% chance of success";

        popDown.SetDown();
    }

    public void Confirm()
    {
        //get task from dictionary indexed by taskname and invoke stored event
        Task.Tasks[tasknameText.text].Invoke();
        popDown.SetUp();
    }
    public void Cancel()
    {
        popDown.SetUp();
    }
}
