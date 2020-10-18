using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class RandomWheelPointer : MonoBehaviour
  {
    public List<string> Names = new List<string>();
    public List<string> Descriptions = new List<string>();


    [SerializeField] private TMP_Text Answer;
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text DescriptionText;

    private float stopTime;
    private float countdown;
    private bool stopped = true;
    private float rotationSpeed = 360;
    void Start()
   
    { 
        stopTime = Random.Range(3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Answer.text = "";
        if (!stopped)
        {
            countdown -= Time.deltaTime;
            if (countdown > 0)
                transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            else
                FinishSpin();
        }
    }

    public void Init()
    {
        transform.rotation = Quaternion.identity;
        stopped = false;
        countdown = stopTime;

    }

    private void FinishSpin()
    {
        stopped = true;
        int segment = Mathf.FloorToInt((360 - transform.rotation.eulerAngles.z) / 60);
        int stat = segment % 3;
        CharacterInfo.Stats[stat] += 1;

        NameText.text = Names[stat];
        DescriptionText.text = Descriptions[stat];

        switch (stat)
        {
            case 0:
                Answer.text = "Body + 1";
                break;
            case 1:
                Answer.text = "Mind + 1";
                break;
            case 2:
                Answer.text = "Charm + 1";
                break;
            default:
                Answer.text = "";
                break;
        }

        CreationStageSelector.completedStages[4] = true;
    }
}
