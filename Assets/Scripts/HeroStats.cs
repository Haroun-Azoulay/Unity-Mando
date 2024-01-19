using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroStats : MonoBehaviour
{
    public TMP_Text lvlTxt;
    public TMP_Text xpTxt;
    public TMP_Text poTxt;

    public int lvl;
    public int xp;
    public int po;
    
    public int nextLevelXp = 20;

        public void Levelup()
    {
        if (xp >= nextLevelXp) 
        {
            xp -= nextLevelXp;
            nextLevelXp += 5;
            lvl++;
            Levelup();
            int statsPoints = PlayerPrefs.GetInt("statsPoints", 0);
            PlayerPrefs.SetInt("statsPoints", statsPoints + 2);
        }
    }


    public void SetGUIVals()
    {
        lvlTxt.text = "Level " + lvl; 
        xpTxt.text = "XP: " + xp + "/" + nextLevelXp;
        poTxt.text = po + " Imperial Credits";
    }
}

