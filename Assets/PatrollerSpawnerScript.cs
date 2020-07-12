using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public AudioSource source;
    public GameObject player;
    public GameObject transition;
    private bool alreadyPlayed = false;
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
        if (LastOneSpawnedInYet && lastOne == null && !alreadyPlayed)
        {
            canSpawn = false;
            player.GetComponent<AudioPlay>().finalSound();
            Debug.Log("Last dead");
            alreadyPlayed = true;
            hasSentOutLastDeathYet = true;
            StartCoroutine(monologue());
        }
        if (canSpawn)
        {
            lastOne = Instantiate(thingToSpawn, transform.position, thingToSpawn.transform.rotation) as GameObject; ;
            LastOneSpawnedInYet = true;
            Debug.Log("Last sent");
            canSpawn = false;
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
    IEnumerator monologue()
    {
        Debug.Log("mono");
        yield return new WaitForSeconds(42f);
        transition.GetComponent<SceneTransition>().LoadNextLevel(0);
    }
}
