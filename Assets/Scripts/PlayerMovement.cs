using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float walkSpeed = 15;
    public float runSpeed = 30;
    public int MaxJumps = 0;
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
    private bool isTouchingWall = false;
    
    
    public GameObject head;
    public GameObject projectilePrefab;
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
        timeAtLastStep = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        jumps = MaxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        
        // check if grounded using ground check object
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        //check if touching any wall using wall check objects
        isTouchingWall = Physics.CheckSphere(wallCheckLeft.position,groundDistance,groundMask) || Physics.CheckSphere(wallCheckRight.position,groundDistance,groundMask);
        if(isTouchingWall) Debug.Log("Stranger Danger");


        //check if moving on ground or standing still
        if(isMoving && isGrounded)
        {
            state = State.Walking;
            jumps = MaxJumps;
        }else if(!isMoving && isGrounded)
        {
            state = State.Idle;
            jumps = MaxJumps;
        }else if(!isGrounded)
        {
            state = State.InAir;
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
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //player gets extra jump when starting on platform for some reason
        //help
        if(Input.GetButtonDown("Jump") && jumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2* gravity*gravityScale);
            jumps -=1;
            Debug.Log(jumps);
        }
        
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
        
        CheckisMoving(x,z);
        velocity.y += gravity*Time.deltaTime * gravityScale;
        // move the player
        Vector3 move = transform.right * x + transform.forward*z ;
        controller.Move(move.normalized*speed*Time.deltaTime);
        controller.Move(velocity*Time.deltaTime);

       
       if(isMoving)
        {
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
    //check if player
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
        Instantiate(projectilePrefab,head.transform.position, head.transform.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
}

