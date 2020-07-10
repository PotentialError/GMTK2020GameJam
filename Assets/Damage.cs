using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_injure : MonoBehaviour
{
    public int layer = 8;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layer)
        {
            transform.position = GlobalData.RespawnPosition;
        }
    }
}
