using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestTaker_potion : MonoBehaviour
{
    QuestGiver_potion qg;

    HeroStats hs;

void Start()
{
     hs = GetComponent<HeroStats>();
}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "potion")
        {
            if(qg == null) // Corrected the spelling of null
            {
                qg = other.gameObject.GetComponent<QuestGiver_potion>();
               if(!qg.questPotion.isActive)
                {       
                    qg.questPanelPotion.SetActive(true);
                    qg.questInfos[0].text = qg.questPotion.title;
                    qg.questInfos[1].text = qg.questPotion.description;
                    qg.questInfos[2].text = "XP:" + qg.questPotion.xp + " | Gold: " + qg.questPotion.gold;
                }
                        else // quest active 
            {
                if (qg.questPotion.isCompletedQuest &&  qg.po > 0)
                {
                    qg.DisplayObjectAfterQuest();
                    print("reward = xp +" + qg.xp + " or : " + qg.po);
                    GetComponent<HeroCharactereCollision>().ShowDialCanvasRewardPotion(qg.questCompletedMsg);
                    hs.xp += qg.xp;
                    hs.po += qg.po;
                    qg.po = 0;
                    qg.xp = 0;
                }
            }
                }
        }
    }
        void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "potion")
        {
            
            qg.questPanelPotion.SetActive(false);
            qg = null;
            GetComponent<HeroCharactereCollision>().HideDialCanvasRewardPotion();
        }
    }
      public void TakeQuest()
    {
        qg.questPotion.isActive = true;
        qg.questPanelPotion.SetActive(false);
    }
}
