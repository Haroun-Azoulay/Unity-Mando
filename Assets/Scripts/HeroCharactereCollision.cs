using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class HeroCharactereCollision : MonoBehaviour
{

    public GameObject dialWorldSpace;

     public TMP_Text dialTxt;

    Collider2D otherObj;

     public GameObject dialCanvas;

    public TMP_Text dialCanvasTxt;

    public GameObject dialCanvasReward;

    public TMP_Text dialCanvasRewardTxt;

    public GameObject dialCanvasRewardQuest;

    public TMP_Text dialCanvasRewardQuestTxt;

    public GameObject dialCanvasRewardPotion;

    public TMP_Text dialCanvasRewardPotionTxt;

    public QuestGiver[] quests;

    public  QuestGiver_brother[] questBrother;

    public Quest_brother brother;

    public QuestGiver_potion[] questPotion;

    public Quest_potion potion;

    public GameObject camFight;

    public IEnumerator WaitAndLoadScene(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene(sceneName);
    }
    
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign")
        {
         otherObj = other;
         //dialWorldSpace.SetActive(true);
         PanelBehaviour sb = other.gameObject.GetComponent<PanelBehaviour>();
         sb.ui.SetActive(true);
         // dialTxt. = sb.panelText
        // dialTxt.SetText(sb.panelText);
        }
        if (other.gameObject.tag == "flower")
        {
            otherObj = other;
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        if (other.gameObject.tag == "weapon")
        {
            otherObj = other;
            otherObj.gameObject.SetActive(true);

        }   
        if (other.gameObject.tag == "exit")
        {
            string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
            PlayerPrefs.SetString("Point", point);
            Application.LoadLevel(other.gameObject.name);
        }
        if (other.gameObject.tag == "mob" && !camFight.activeInHierarchy)
        {
            camFight.SetActive(true);
            InitializeFight initF =  camFight.GetComponent<InitializeFight>();
            initF.hfs.baseEnemy = other.gameObject;
            initF.InitFight();
        }
        if (other.gameObject.tag == "blood")
        {
            questPotion[0].questPotion.IncrementCount(); 
            other.gameObject.SetActive(false);
        }
          if (other.gameObject.tag == "treasure")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(WaitAndLoadScene(3, "End_game"));
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "guard")
        {
            PnjSimpleDial pnjDial = other.gameObject.GetComponent<PnjSimpleDial>();
            if (pnjDial != null && dialCanvasTxt != null)
            {
                // Activez le canvas de dialogue si pas null
                if (dialCanvas != null)
                {
                    dialCanvas.SetActive(true);
                }
                else
                {
                    Debug.LogError("dialCanvas is not set in the Inspector");
                }
                dialCanvasTxt.text = pnjDial.SimpleDial;
            }
            else
            {
                Debug.LogError("PnjSimpleDial component is missing or dialCanvasTxt is not set");
            }
        }
        if (other.gameObject.tag == "brother")
        {
            // Vérifiez si brother est déjà assigné, sinon récupérez-le
            if (brother == null)
            {
                brother = other.gameObject.GetComponent<Quest_brother>();
            }

            if (brother != null)
            {
                questBrother[0].questBrother.IncrementCount(); 
            }
            else
            {
                Debug.LogError("Quest_brother component is missing on brother object");
            }
        }
         if (other.gameObject.tag == "potion")
            {
            
                if (potion == null)
                {
                    potion = other.gameObject.GetComponent<Quest_potion>();
                }

                else
                {
                    Debug.LogError("Quest_brother component is missing on brother object");
                }
            }
    }

    void OnCollisionExit2D(Collision2D other)
    {
       if (other.gameObject.tag == "guard")
        {
            dialCanvas.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign")
        {   
            PanelBehaviour sb = other.gameObject.GetComponent<PanelBehaviour>();
            sb.ui.SetActive(false);
            otherObj = null;
            Invoke("HideDialPanel", 1);
        }
        if (other.gameObject.tag == "flower")
        {
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObj = null;
        }
        if (other.gameObject.tag == "weapon")
        {
            otherObj.gameObject.SetActive(false);
            otherObj = null;

        }       
    }

    void HideDialPanel()
    {
        dialWorldSpace.SetActive(false);
    }

    public void Update(){
        if(Input.GetKeyUp(KeyCode.E) && otherObj != null)
        {
        if (otherObj.gameObject.tag == "sign")
            ShowDial();
        if (otherObj.gameObject.tag == "flower")
        {
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObj.gameObject.SetActive(false);
            otherObj = null;
            quests[0].quest.IncrementCount();
        }
        }
        if(Input.GetKeyUp(KeyCode.R) && otherObj != null)
        {
        if (otherObj.gameObject.tag == "weapon")
        {
            Debug.Log("weapon is here");
            otherObj.gameObject.SetActive(false);
            otherObj = null;
        }
        }
  
                 
    }


    public void ShowDial()
    {   
        PanelBehaviour sb = otherObj.gameObject.GetComponent<PanelBehaviour>();
        sb.ui.SetActive(false);
        dialWorldSpace.SetActive(true);
        // dialTxt. = sb.panelText
        dialTxt.SetText(sb.panelText);
    }

    public void ShowDialCanvasReward(string msg)
        {
            dialCanvasReward.SetActive(true);
            dialCanvasRewardTxt.text = msg;
        }
    
    public void HideDialCanvasReward()
    {
        dialCanvasReward.SetActive(false);
    }
    // brother
    public void ShowDialCanvasRewardQuest(string msg)
    {
        dialCanvasRewardQuest.SetActive(true);
        dialCanvasRewardQuestTxt.text = msg;
    }
    
    public void HideDialCanvasRewardQuest()
    {
        dialCanvasRewardQuest.SetActive(false);
    }
    
    public void HideDialCanvasRewardPotion()
    {
        dialCanvasRewardPotion.SetActive(false);
    }
    public void ShowDialCanvasRewardPotion(string msg)
    {
        dialCanvasRewardPotion.SetActive(true);
        dialCanvasRewardPotionTxt.text = msg;
    }
}