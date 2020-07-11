using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int enemyHealth;
    public GameObject hitEffect;
    public GameObject deathEffect;
    private bool canBeDamaged = true;
    public float enemyDamageCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageEnemy(int damage)
    {
        if (canBeDamaged)
        {
            canBeDamaged = false;
            enemyHealth -= damage;

            //activate hit animation here

            if (enemyHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                StartCoroutine(resetEnemy());
            }
        }
    }

    IEnumerator resetEnemy()
    {
        yield return new WaitForSeconds(enemyDamageCooldown);
        canBeDamaged = true;
    }
}
