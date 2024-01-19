using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]


public class Quest_brother
{
    public string title;

    public string description;

    public string gold;

    public int xp;

    public bool isActive;

    public bool isCompletedQuest = false;

    public string objType;

    public int count = 0;

     public void IncrementCount()
    {
        count++;
        if(count >= 1)
        {
            isCompletedQuest = true;
        }
    }

}