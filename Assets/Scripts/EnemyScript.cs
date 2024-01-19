using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int vie = 3;

    public int force = 1;

    public GameObject healthBar;

    float scaleX;

    public GameObject hero;

    Vector3 initialPos;
    HeroFightScript hfs;

    void Start()
    {
        initialPos = transform.position;
        hfs = hero.GetComponent<HeroFightScript>();
        scaleX = healthBar.transform.localScale.x / vie;
    }

public void SetLifeBar()
{
    healthBar.transform.localScale = new Vector3(scaleX * vie, 0.125f, 1);
}
void FixedUpdate()
{
    healthBar.transform.localScale = new Vector3(scaleX * vie, 0.125f, 1);
}

public void AtkHero()
{
    if(gameObject.activeInHierarchy)
    StartCoroutine("PlayAtk");
}

IEnumerator PlayAtk()
{
    yield return new WaitForSeconds(0.5f);
    iTween.MoveTo(gameObject, hero.transform.position, 0.3f);
    hfs.vie -= force;
    yield return new WaitForSeconds(0.3f);
    iTween.MoveTo(gameObject, initialPos, 0.6f);
    if(hfs.vie <= 0)
    {
        print("Perdu");
    }
    hfs.canFight = true;

}    
}
