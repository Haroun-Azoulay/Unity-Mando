using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest_potion
{
    public string title;

    public string description;

    public string gold;

    public int xp;

    public bool isActive;

    public  bool isCompletedQuest = false;

    public string objType;

    public int reqAmount;

    public int count = 0;

    public void IncrementCount()
    {
        count++;
        Debug.Log("Count incremented to: " + count);
        if(count == reqAmount )
        {
            isCompletedQuest = true;
            Debug.Log("Quest completed!");
        }
    }
}
