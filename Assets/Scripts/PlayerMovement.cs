using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float walkSpeed = 15;
    public float runSpeed = 30;
    private float speed = 0;

    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public AudioClip[] walkSounds;
    private AudioSource audioSource;
    private GameManager gameManager;
    public float timeBetweenSteps = 1f;

    private bool isWalking = false;
    private bool isRunning = false;
    public Rigidbody head;
    private float timeAtLastStep;
   

    public float gravity = -9.81f;
    // Start is called before the first frame update

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeAtLastStep = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(Input.GetButton("Run"))
        {
            isRunning = true;
            speed = runSpeed;
            timeBetweenSteps = 0.5f;

        }
        else{
            isRunning = false;
            speed = walkSpeed;
            timeBetweenSteps = 1f;
        }
        Debug.Log(isRunning);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2* gravity);
        }
        
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
        
        CheckisWalking(x,z);
        velocity.y += gravity*Time.deltaTime;

       
       if(isWalking)
        {
            /*
            if(Time.time - timeAtLastStep > timeBetweenSteps)
            {
                audioSource.PlayOneShot(walkSounds[Random.Range(0,walkSounds.Length)]);
                timeAtLastStep = Time.time;
            }
            */
        }    
       

        
        
    }
   void CheckisWalking(float x,float z)
   {
     if(isGrounded)
        {
            if(x!=0||z!=0)
            {
                isWalking = true;
                
            }else{
                isWalking = false;
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        
    }
}

