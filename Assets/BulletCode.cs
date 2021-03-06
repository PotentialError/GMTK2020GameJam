﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public float speed = 20;
    public float damage = 1;
    public GameObject BulletHitParticles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 100 || transform.position.x < -100)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==11)
        {
            collision.gameObject.GetComponent<DamageEnemy>().damageEnemy(1);
        }
        if(collision.tag != "Player" && collision.tag != "Respawn")
        {
            Destroy(this.gameObject);
            Instantiate(BulletHitParticles, transform.position, BulletHitParticles.transform.rotation);
        }

    }
}
