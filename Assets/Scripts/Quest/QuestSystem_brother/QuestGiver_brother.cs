using System.Runtime;
using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver_brother : MonoBehaviour
{
    public Quest_brother questBrother;
    public GameObject questPanelBrother;
    public Text[] questInfos;
    public string questCompletedMsg;
    public int xp = 50;
    public int po = 500;
    public GameObject[] DisplayAfterQuestCompleted;
    public GameObject[] HideAfterQuestCompleted;
    

    public void DisplayObjectAfterQuest()
    {
        foreach(GameObject go in DisplayAfterQuestCompleted)
        {
            go.SetActive(true);
            
        }
    }
    public void HideObjectAfterQuest()
    {
        foreach(GameObject go in HideAfterQuestCompleted)
        {
            go.SetActive(false);
            
        }
    }
}
