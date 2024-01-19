using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Mime;
using UnityEngine.UI;
using TMPro;

public class IncreaseStats : MonoBehaviour
{
    public int statsPoints;

    public int strength;
    public int force;
    public int speed;

    public TMP_Text strengthTxt; 
    public TMP_Text forceTxt;
    public TMP_Text speedTxt; 

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        SetTxt();
        RefreshStatsPoints();
    }

    public void RefreshStatsPoints()
    {
        statsPoints = PlayerPrefs.GetInt("statsPoints", 0);
    }
    public void IncreaseSelectedStat(string statName)
    {   
        if(statsPoints > 0)
        {
        statsPoints--;
        PlayerPrefs.SetInt("statsPoints", statsPoints);
        PlayerPrefs.SetInt(statName, PlayerPrefs.GetInt(statName, 1) + 1);
        SetTxt();
        }
    }

    public void SetTxt()
    {
        strengthTxt.text = "Strength: " + PlayerPrefs.GetInt("strength", 1);
        forceTxt.text = "Force: " + PlayerPrefs.GetInt("force", 1);
        speedTxt.text = "Speed: " + PlayerPrefs.GetInt("speed", 1);
    }
}