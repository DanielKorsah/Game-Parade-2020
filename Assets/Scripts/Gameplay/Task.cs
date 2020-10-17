using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Task : Interactable
{
    public Sprite SucceededSprite;
    public Sprite FailedSprite;

    public UnityEvent TaskConfirmation;
    public static Dictionary<string, UnityEvent> Tasks = new Dictionary<string, UnityEvent>();

    public string TaskName = "Default";
    [TextArea] public string TaskDescription = "Do the thing.";
    public bool succeeded;
    private SpriteRenderer icon;


    [SerializeField] [Range(0, 2)] private int statUsed = 0;
    [SerializeField] [Range(0, 2)] private int difficultyTier;
    private int difficultyModifier = 0;
    private Color[] colours = new Color[3];
    private float probability;
    private float percentChance;
    private int notorietyYield;


    protected override void Start()
    {
        base.Start();


        TaskConfirmation = new UnityEvent();
        TaskConfirmation.AddListener(TriggerTask);
        Tasks.Add(TaskName, TaskConfirmation);


        ColorUtility.TryParseHtmlString("#5C9B83", out colours[0]);
        ColorUtility.TryParseHtmlString("#C99245", out colours[1]);
        ColorUtility.TryParseHtmlString("#C94545", out colours[2]);
        icon = base.visualiser.GetComponent<SpriteRenderer>();
        icon.color = colours[difficultyTier];

        switch (difficultyTier)
        {
            case 0:
                difficultyModifier = 6;
                notorietyYield = 2;
                break;
            case 1:
                difficultyModifier = 3;
                notorietyYield = 5;
                break;
            case 2:
                difficultyModifier = 0;
                notorietyYield = 6;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    protected override void Interaction()
    {
        probability = (difficultyModifier + CharacterInfo.Stats[statUsed]) / 10.0f;
        TaskConfirm.TaskInteraction.Invoke(TaskName, TaskDescription, (float)System.Math.Round(probability * 100.0f, 2), statUsed);
        Debug.Log("Interacted with task: " + TaskName);
    }

    private void TriggerTask()
    {
        float roll = Random.Range(0.0f, 1.0f);
        if (roll <= probability)
        {
            succeeded = true;
            icon.sprite = SucceededSprite;
            icon.color = colours[0];
            NotorietyMeter.NotorietyChange.Invoke(notorietyYield);
        }
        else
        {
            succeeded = false;
            icon.sprite = FailedSprite;
            icon.color = colours[2];
        }
        base.useable = false;
        CharacterInfo.TimeAdvanceEvent.Invoke();
    }
}