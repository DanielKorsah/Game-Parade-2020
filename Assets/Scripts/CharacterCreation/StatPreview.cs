using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class StatPreview : MonoBehaviour
{


    //0 body, 1 mind, 2 charm
    public static int modifiedStat = -1;
    public static List<int> modifications = new List<int>();

    public static UnityEvent RefreshStatBlocks = new UnityEvent();

    public static int BodyModifierTotal = 0;
    public static int MindModifierTotal = 0;
    public static int CharmModifierTotal = 0;

    [SerializeField] TMP_Text[] statText;

    void Start()
    {
        RefreshStatBlocks.AddListener(Refresh);

        statText[0].text = "Body: " + CharacterInfo.Stats[0];
        statText[1].text = "Mind: " + CharacterInfo.Stats[1];
        statText[2].text = "Charm: " + CharacterInfo.Stats[2];
    }

    public void SetModifiedStat(int stat)
    {
        modifiedStat = stat;
        RefreshStatBlocks.Invoke();
    }

    public static void Next()
    {
        if (modifiedStat != -1)
        {
            modifications.Add(modifiedStat);
            CreationStageSelector.completedStages[CreationStageSelector.progress] = true;
        }
        modifiedStat = -1;
    }
    public static void Back(int stage)
    {
        modifiedStat = -1;
        modifications.RemoveAt(modifications.Count - 1);

    }

    private void Refresh()
    {
        //reset from 0 before summing
        BodyModifierTotal = 0;
        MindModifierTotal = 0;
        CharmModifierTotal = 0;

        //sum of all previous modifications
        foreach (int i in modifications)
        {
            if (i == 0)
                BodyModifierTotal++;
            else if (i == 1)
                MindModifierTotal++;
            else if (i == 2)
                CharmModifierTotal++;
        }

        //show changes
        switch (modifiedStat)
        {
            //visual indicators
            case 0:
                statText[0].text = "Body: " + (CharacterInfo.Stats[0] + BodyModifierTotal + 1);
                statText[1].text = "Mind: " + (CharacterInfo.Stats[1] + MindModifierTotal);
                statText[2].text = "Charm: " + (CharacterInfo.Stats[2] + CharmModifierTotal);
                break;
            case 1:
                statText[0].text = "Body: " + (CharacterInfo.Stats[0] + BodyModifierTotal);
                statText[1].text = "Mind: " + (CharacterInfo.Stats[1] + MindModifierTotal + 1);
                statText[2].text = "Charm: " + (CharacterInfo.Stats[2] + CharmModifierTotal);
                break;
            case 2:
                statText[0].text = "Body: " + (CharacterInfo.Stats[0] + BodyModifierTotal);
                statText[1].text = "Mind: " + (CharacterInfo.Stats[1] + MindModifierTotal);
                statText[2].text = "Charm: " + (CharacterInfo.Stats[2] + CharmModifierTotal + 1);
                break;
            default:
                Debug.Log("Wrong index");
                break;
        }
    }

}
