using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStand : MonoBehaviour
{
    public Sprite newSprite;
    public GameObject arm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            collision.gameObject.GetComponent<Shoot>().enabled = true;
            arm.SetActive(true);
            collision.gameObject.GetComponent<PlayerControl>().noGun = false;
        }
    }
}
