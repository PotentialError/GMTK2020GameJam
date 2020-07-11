using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float distanceUp;
    public float speed;
    public Vector2 target;
    public float startTransition;
    public GameObject transition;
    private bool isDetected;
    public float elevatorTime = 3f;
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
            transition.GetComponent<SceneTransition>().LoadNextLevel(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
