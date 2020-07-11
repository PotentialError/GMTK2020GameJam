using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
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
}
