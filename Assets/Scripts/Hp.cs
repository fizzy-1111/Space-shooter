using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    [SerializeField] int RegenerateAmount = 1;
    [SerializeField] float RegenerationRate = 2f;
    [SerializeField] GameObject target;

    private void Start()
    {
        curHealth = maxHealth;
        if(target == GameObject.FindGameObjectWithTag("Player"))
        InvokeRepeating("Regenerate", RegenerationRate,RegenerationRate);
    }
    void Regenerate()
    {
        if (curHealth < maxHealth) curHealth += RegenerateAmount;
        if (curHealth > maxHealth) curHealth = maxHealth;
        EventManager.TakeDmg(curHealth / (float)maxHealth);
    }
 
    public void takeDamage(int dmg = 1)
    {
        curHealth -= dmg;
        if (curHealth < 0) curHealth = 0;
        if (curHealth < 1)
        {
            if (target == GameObject.FindGameObjectWithTag("Player"))
                GetComponent<Explosion>().blowUp();
            else GetComponent<Explosion>().blowUpOthers() ;

        }
        if (target == GameObject.FindGameObjectWithTag("Player"))
        EventManager.TakeDmg(curHealth / (float)maxHealth);
    }
}
