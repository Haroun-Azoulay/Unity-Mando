using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTaker : MonoBehaviour
{

    QuestGiver qg;

    HeroStats hs;
void Start()
{
     hs = GetComponent<HeroStats>();
}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        {
                if(qg == null)
                {
            qg = other.gameObject.GetComponent<QuestGiver>();
            if(!qg.quest.isActive) // quest none activate
            {
            qg.questPanel.SetActive(true);
            qg.questInfos[0].text = qg.quest.title;
            qg.questInfos[1].text = qg.quest.description;
            qg.questInfos[2].text = "XP:" + qg.quest.xp + " | Gold: " + qg.quest.gold;
            }
            else // quest active 
            {
                if (qg.quest.isCompleted &&  qg.po > 0)
                {
                    qg.HideObjectAfterQuest();
                    print("reward = xp +" + qg.xp + " or : " + qg.po);
                    GetComponent<HeroCharactereCollision>().ShowDialCanvasReward(qg.questCompletedMsg);
                    hs.xp += qg.xp;
                    hs.po += qg.po;
                    qg.po = 0;
                    qg.xp = 0;
                    hs.Levelup();
                    hs.SetGUIVals();
                }
            }
                }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        {
            qg.questPanel.SetActive(false);
            qg = null;
            GetComponent<HeroCharactereCollision>().HideDialCanvasReward();
        }
    }
    public void TakeQuest()
    {
        qg.quest.isActive = true;
        qg.questPanel.SetActive(false);
    }
}
