using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Damage : MonoBehaviour
{
    public int Spikelayer = 8;
    public int Enemylayer = 11;

    public GameObject deathEffects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Spikelayer)
        {
            kill();
        }
        if(collision.gameObject.layer == Enemylayer)
        {
            kill();
        }
    }

    IEnumerator death()
    {
        Instantiate(deathEffects, transform.position, deathEffects.transform.rotation);
        transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        transform.position = GlobalData.RespawnPosition;
        transform.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void kill()
    {
        StartCoroutine(death());
    }
}
