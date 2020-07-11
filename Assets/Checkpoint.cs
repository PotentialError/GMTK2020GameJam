using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GlobalData.RespawnPosition = spawnPoint.position;
            GetComponent<Animator>().SetTrigger("checkPoint");
        }
    }
}
