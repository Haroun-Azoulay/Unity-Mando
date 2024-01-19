using System.Runtime;
using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver_potion : MonoBehaviour
{
    public Quest_potion questPotion;

    public GameObject questPanelPotion;

    public Text[] questInfos;

    public string questCompletedMsg;

    public int xp = 150;

    public int po = 1000;

    public GameObject[] DisplayAfterQuestCompleted;
    
      public void DisplayObjectAfterQuest()
    {
        foreach(GameObject go in DisplayAfterQuestCompleted)
        {
            go.SetActive(true);
            
        }
    }
}
