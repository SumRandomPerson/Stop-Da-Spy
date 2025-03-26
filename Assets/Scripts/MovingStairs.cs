using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStairs : MonoBehaviour
{
    public float speed;
    float startSpeed;
    public int direction = 1;
    public float timer;
    float currentTime;
    PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Awake()
    {
        currentTime = timer;
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startSpeed = speed;


    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime < 1)
        {
            direction = -direction;
            currentTime = timer;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime * direction);

        if (playerMovementScript.timeStop == true)
        {
            speed = 0;
        } else 
        {
            speed = startSpeed;
        }
    }
}
