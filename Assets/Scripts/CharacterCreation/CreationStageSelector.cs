using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreationStageSelector : MonoBehaviour
{

    public static bool[] completedStages = { true, false, false, false, false };
    //0 - sprite select, 1 - childhood, 2 - adulthood, 3 - later adulthood, 4 random wheel
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

        if (progress == 4)
            GameObject.FindObjectOfType<RandomWheelPointer>().Init();

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
        if (progress == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        //if last page with options show finish instead of Next,
        else if (progress == 3)
        {
            nextText.text = "Finish";
        }
        // if random wheel page show Play, also lock back button out so decisions are finalised
        else if (progress == 4)
        {
            nextText.text = "Play";
            backButton.gameObject.SetActive(false);
        }
        else
        {
            nextText.text = "Next";
            backButton.gameObject.SetActive(true);
        }

        //0,1,2,3,4 set panels visible or not
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

        //if progresing past 3rd stage of character creation, set character stats
        if (progress == 4)
        {
            CharacterInfo.Stats = new List<int>() { StatPreview.BodyModifierTotal + 1, StatPreview.MindModifierTotal + 1, StatPreview.CharmModifierTotal + 1 }.ToArray();
            StatblockPrinter.UpdateStatsUI.Invoke();
        }

        //if all steps complete, load game scene
        if (progress > 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
