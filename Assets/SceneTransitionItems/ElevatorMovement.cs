using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float distanceUp;
    public float speed;
    public float startTransition;
    public GameObject transition;
    private bool isDetected;
    public float elevatorTime = 3f;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        isDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDetected)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (transform.position.y >= startTransition)
        {
            transition.GetComponent<SceneTransition>().LoadNextLevel(level);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(timer());
            GetComponent<Animator>().SetTrigger("PlayerIn");
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(elevatorTime);
        isDetected = true;
    }
}
