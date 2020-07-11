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
            if(GlobalData.checkPointAmount > 2)
            {
                GlobalData.RespawnPosition = spawnPoint.position;
                GlobalData.checkPointAmount = 0;
            }
            else
            {
                GlobalData.RespawnPosition = transform.position;
                GlobalData.checkPointAmount++;
            }
            GetComponent<Animator>().SetTrigger("checkPoint");
        }
    }
}
