using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTaker_brother : MonoBehaviour
{

    QuestGiver_brother qg;

    HeroStats hs;
void Start()
{
     hs = GetComponent<HeroStats>();
}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver_brother")
        {
                if(qg == null)
                {
            qg = other.gameObject.GetComponent<QuestGiver_brother>();
            if(!qg.questBrother.isActive) // quest none activate
            {
            qg.questPanelBrother.SetActive(true);
            qg.questInfos[0].text = qg.questBrother.title;
            qg.questInfos[1].text = qg.questBrother.description;
            qg.questInfos[2].text = "XP:" + qg.questBrother.xp + " | Gold: " + qg.questBrother.gold;
            }
            else // quest active 
            {
                if (qg.questBrother.isCompletedQuest &&  qg.po > 0)
                {
                    qg.DisplayObjectAfterQuest();
                    qg.HideObjectAfterQuest();
                    print("reward = xp +" + qg.xp + " or : " + qg.po);
                    GetComponent<HeroCharactereCollision>().ShowDialCanvasRewardQuest(qg.questCompletedMsg);
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

        if (other.gameObject.tag == "quest_giver_brother")
        {
            qg.questPanelBrother.SetActive(false);
            qg = null;
            GetComponent<HeroCharactereCollision>().HideDialCanvasRewardQuest();
        }
    }
    public void TakeQuest()
    {
        qg.questBrother.isActive = true;
        qg.questPanelBrother.SetActive(false);
    }
}


