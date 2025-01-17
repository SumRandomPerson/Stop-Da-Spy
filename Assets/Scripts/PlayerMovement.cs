using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float walkSpeed = 15;
    public float runSpeed = 30;
    public int maxJumps = 2;
    private int jumps;
    private float speed = 0;

    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public AudioClip[] walkSounds;
    private AudioSource audioSource;
    private GameManager gameManager;
    public float timeBetweenSteps = 1f;

    private bool isMoving = false;
    private bool isRunning = false;
    //private bool isTouchingWall = false;
    
    
    public GameObject head;
    public GameObject projectilePrefab;
    private MouseLook lookScript;
    private float timeAtLastStep;
    public enum State
    {
        Idle,
        Walking,
        InAir,
        Wallrunning,
    }
    private State state = State.Walking;
   

    private float gravity = -9.81f;
    public float gravityScale = 1f;
    // Start is called before the first frame update

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lookScript = head.gameObject.GetComponent<MouseLook>();
        timeAtLastStep = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        jumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // check if grounded using ground check object
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        //check if touching any wall using wall check objects
        bool isTouchingWallRight = Physics.CheckSphere(wallCheckRight.position,groundDistance,groundMask);
        bool isTouchingWallLeft  = Physics.CheckSphere(wallCheckLeft.position,groundDistance,groundMask);
        if(isTouchingWallRight) Debug.Log("Wall on right");
        if(isTouchingWallLeft) Debug.Log("Wall on left");



        //check if moving on ground or standing still
        if(Input.GetButtonDown("Jump") && jumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2* gravity*gravityScale);
            jumps -=1;
            Debug.Log(jumps);
        }
       


        switch(state)
        {
            case State.Walking:
            // move the player
            
            Vector3 move = transform.right * x + transform.forward*z;
            controller.Move(move.normalized*speed*Time.deltaTime);
            velocity.y += gravity*Time.deltaTime * gravityScale;
            controller.Move(velocity*Time.deltaTime);
            if(x < 0)
            {
                TiltCameraDegrees(10f,0.05f);
            }else if(x > 0)
            {
                TiltCameraDegrees(-10f,0.05f);
            }else  TiltCameraDegrees(0f,0.05f);
            
            if(!isMoving && isGrounded) state = State.Idle;
            if(!isGrounded)
            {
                state = State.InAir;
            }
           
             
            break;
            case State.InAir:
            // move the player
            TiltCameraDegrees(0f,0.05f);
            move = transform.right * x + transform.forward*z;
            controller.Move(move.normalized*speed*Time.deltaTime);
            velocity.y += gravity*Time.deltaTime * gravityScale;
            controller.Move(velocity*Time.deltaTime);
            if(isGrounded)
            {
                state = State.Walking;
                jumps = maxJumps;
            }
            
             
            break;
            case State.Idle:
            // move the player
            TiltCameraDegrees(0f,0.05f);
            move = transform.right * x + transform.forward*z;
            controller.Move(move.normalized*speed*Time.deltaTime);
            velocity.y += gravity*Time.deltaTime * gravityScale;
            controller.Move(velocity*Time.deltaTime);
            if(isMoving && isGrounded)
            {
                state = State.Walking;
                
            }
            if(!isGrounded)
            {
                state = State.InAir;
            }
             
            break;
        }
       
       
        






        if(Input.GetButton("Run"))
        {
            //set running state and change speed and footstep time
            isRunning = true;
            speed = runSpeed;
            timeBetweenSteps = 0.5f;

        }
        else{
            
            isRunning = false;
            speed = walkSpeed;
            timeBetweenSteps = 1f;
        }
        //bring player to the floor if not on it
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //player gets extra jump when starting on platform for some reason
        //help
        
        
        
           
            
        
        CheckisMoving(x,z);
       
        

       
       if(isMoving)
        {//unused footstep logic
            /*
            if(Time.time - timeAtLastStep > timeBetweenSteps)
            {
                audioSource.PlayOneShot(walkSounds[Random.Range(0,walkSounds.Length)]);
                timeAtLastStep = Time.time;
            }
            */
        }    


        if(Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
       

       
       // Debug.Log(state);
        
    }
    //check if player moving
   void CheckisMoving(float x,float z)
   {
     
        if(x!=0||z!=0)
        {
            isMoving = true;
                
        }else{

            isMoving = false;
        }
        

    }
    void ShootProjectile()
    {
        Instantiate(projectilePrefab, head.transform.position, head.transform.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
    void TiltCameraDegrees(float target, float interpo)
    {
        lookScript.SetTilt(Mathf.Lerp(lookScript.GetTilt(),target,interpo));
    }
}

