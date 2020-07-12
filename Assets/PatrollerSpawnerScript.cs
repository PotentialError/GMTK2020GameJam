using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerSpawnerScript : MonoBehaviour
{
    public int totalSpawns;
    private int currentSpawnNum = 0;
    public GameObject thingToSpawn;
    public float spawnCooldown;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnNum = totalSpawns;
        StartSpawning(); //this is in case there is an audio clip that should run before it starts spawning or something
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSpawning()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        Instantiate(thingToSpawn, transform.position, thingToSpawn.transform.rotation);
        yield return new WaitForSeconds(spawnCooldown);
        Debug.Log("help");
        currentSpawnNum += 1;
        if(!(currentSpawnNum>totalSpawns))
            StartCoroutine(spawn());
    }
}
