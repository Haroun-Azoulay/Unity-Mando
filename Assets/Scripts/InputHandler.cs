using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public GameObject panelStats;
    public IncreaseStats increaseS;

    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Escape))
       {
        increaseS.RefreshStatsPoints();
        Time.timeScale = 0;
        panelStats.SetActive(true);
       }
    }

    public void SetTimescaleToOne()
    {
        Time.timeScale = 1;
    }
}
