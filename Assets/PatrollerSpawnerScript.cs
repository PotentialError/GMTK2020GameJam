using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerSpawnerScript : MonoBehaviour
{
    public int totalSpawns;
    public int currentSpawnNum = 0;
    public GameObject thingToSpawn;
    public float spawnCooldown;
    private bool canSpawn = true;
    private GameObject lastOne;
    private bool LastOneSpawnedInYet = false;
    private bool hasSentOutLastDeathYet = false;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning(); //this is in case there is an audio clip that should run before it starts spawning or something
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn&&currentSpawnNum<totalSpawns-1)
        {
            currentSpawnNum += 1;
            Instantiate(thingToSpawn, transform.position, thingToSpawn.transform.rotation);
            canSpawn = false;
            StartCoroutine(spawn());
        }
        if (LastOneSpawnedInYet && !hasSentOutLastDeathYet && lastOne == null)
        {
            canSpawn = false;
            Debug.Log("Last dude has died");
            hasSentOutLastDeathYet = true;
        }
        if (canSpawn)
        {
            GameObject lastOne = Instantiate(thingToSpawn, transform.position, thingToSpawn.transform.rotation); 
            LastOneSpawnedInYet = true;
        }
    }
    public void StartSpawning()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }
}
