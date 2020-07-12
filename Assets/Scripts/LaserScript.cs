using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private bool hasKilled = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopLaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StopLaser()
    {
        yield return new WaitForSeconds(0.125f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {/*
        if (!hasKilled&&collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.GetComponent<Damage>().kill();
            hasKilled = true;
        }
    */}
}
