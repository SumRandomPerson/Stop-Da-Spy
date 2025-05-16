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
    private TimeManager time;
    // Start is called before the first frame update
    void Awake()
    {
        currentTime = timer;
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startSpeed = speed;


    }
    void Start()
    {
        time = GameObject.Find("Game Manager").GetComponent<TimeManager>();

    }
    // Update is called once per frame
    void Update()
    {
        if (!time.isStopped)
        {
                MoveStairs();
        }
    }

    public void MoveStairs()
    {
                currentTime -= Time.deltaTime;

        if(currentTime < 1)
        {
            direction = -direction;
            currentTime = timer;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime * direction);

        if (time.isStopped)
        {
            speed = 0;
        } else 
        {
            speed = startSpeed;
        }
    }
}
