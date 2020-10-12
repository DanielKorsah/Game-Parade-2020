using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreationStageSelector : MonoBehaviour
{

    public static bool[] completedStages = { true, false, false, false };
    //0 - sprite select, 1 - childhood, 2 - adulthood, 3 - later adulthood,
    public static int progress;

    [SerializeField] private List<GameObject> stagePanels = new List<GameObject>();
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_Text nextText;

    void Start()
    {
        progress = 0;
        Resolve();
    }

    public void Forward()
    {
        if (progress > 0 && progress < 4)
            StatPreview.Next();

        if (completedStages[progress])
            progress++;
        Resolve();
    }

    public void Back()
    {

        if (progress > 0)
        {
            if (progress > 1 && progress < 5)
                StatPreview.Back(progress);

            //set current stage to inclomplete
            completedStages[progress] = false;

            //decrement to previous stage
            progress--;

            //set previous (now current) stage to incomplte
            if (progress > 0)
                completedStages[progress] = false;
        }


        Resolve();
    }


    private void Resolve()
    {


        //Don't show back button on first stage
        //if (progress == 0)
        //backButton.gameObject.SetActive(false);
        //else
        //backButton.gameObject.SetActive(true);

        //if last page show finish instead of Next
        if (progress == 3)
            nextText.text = "Finish";
        else
            nextText.text = "Next";

        //0,1,2,3 set panels visible or not
        if (progress < stagePanels.Count)
        {

            for (int i = 0; i < stagePanels.Count; i++)
            {
                if (i == progress)
                    stagePanels[i].GetComponent<PopDown>().SetDown();
                else
                    stagePanels[i].GetComponent<PopDown>().SetUp();
            }
        }

        //if progresing past 3rd stage of character creation, set character stats and load next scene
        if (progress > 3)
        {
            CharacterInfo.Stats = new List<int>() { StatPreview.BodyModifierTotal + 1, StatPreview.MindModifierTotal + 1, StatPreview.CharmModifierTotal + 1 }.ToArray();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
