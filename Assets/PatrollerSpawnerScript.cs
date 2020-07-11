using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerSpawnerScript : MonoBehaviour
{
    public int totalSpawns;
    private int currentSpawnNum;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnNum = totalSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
