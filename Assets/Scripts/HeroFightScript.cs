using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFightScript : MonoBehaviour
{
    public int vie = 10;

    public int force = 2;

    public GameObject enemy;

    Vector3 initialPos;
    EnemyScript enemyScript;

    public bool canFight = true;

    public GameObject camFight;

    public GameObject baseEnemy;
    void Start() {
        initialPos = transform.position;
        enemyScript = enemy.GetComponent<EnemyScript>();
    }
    public void Atk1()
    {
        if(canFight)
        {
        StartCoroutine("PlayAtk");
        canFight = false;
        }
    }
    IEnumerator PlayAtk()
    {
        iTween.MoveTo(gameObject, enemy.transform.position, 0.4f);
        enemyScript.vie -= force;
        enemyScript.SetLifeBar();
        yield return new WaitForSeconds(0.45f);
        iTween.MoveTo(gameObject, initialPos, 0.8f);
        if(enemyScript.vie <= 0)
        {
            MobBehaviour mb = baseEnemy.GetComponent<MobBehaviour>();
            if(mb.loot != null)
            {
                mb.DropLoot();
            }
            enemy.SetActive(false);
            baseEnemy.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            camFight.SetActive(false);
            HeroStats hs = GameObject.FindObjectOfType<HeroStats>().GetComponent<HeroStats>();
            hs.xp += 10;
            hs.Levelup();
            hs.SetGUIVals();
        }
        enemyScript.AtkHero();


    }
}

