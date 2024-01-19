using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFight : MonoBehaviour
{
  public GameObject mob;
  
  public HeroFightScript hfs;

  EnemyScript es;

  public void InitFight()
  {
    mob.SetActive(true);
    es = mob.GetComponent<EnemyScript>();
    es.vie = 3;
    hfs.canFight = true;
    es.SetLifeBar();


  }

}
