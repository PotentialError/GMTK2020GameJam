using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
