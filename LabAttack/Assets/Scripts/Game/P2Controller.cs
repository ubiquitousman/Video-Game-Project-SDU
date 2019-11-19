using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : MonoBehaviour
{
    public float moveSpeed; //the speed the player is able to move with
    public float jumpForce; //how high the player jump

    //since we want two players in the game, there's no reason to make public predetermined controls. Instead we'll make KeyCode public, so we can alter the controls for each player easily inside Unity
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    private Rigidbody2D rb; //declares variable to give the player gravity and the ability to interact with physics

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround; //we want to define what ground is - how to make the player check if it's standing on the ground

    public bool isGrounded; //it's either true or false if the player is on the ground

    private Animator anim; //making a reference to the animator which is attached to the player

    public GameObject laserBeam;
    public Transform shootPoint; //where the point (in space) of shooting the laserbeam is located

    public AudioSource shootSound;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>(); //when the game starts we want this script to find the rigidbody that is attached to the player

        anim = GetComponent<Animator>(); //when the game starts we want this script to find the animations stored in Animator
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround); //it will draw a "circle" and check if the ground is within the circle. If it is then it will tell us if isGrounded is true. If not, it's false
    

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); //if we press the key that corresponds with KeyCode left, then we want the rigidbody to move to the left
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //if we press the key that corresponds with KeyCode right, then we want the rigidbody to move to the right
        }
        else
        { 
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(Input.GetKeyDown(jump) && isGrounded) //if the button is just pressed (and not held down), then force will be added, so the player jumps into the air if the player is on the ground when pressed
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }

        if(Input.GetKeyDown(shoot))
        {
            GameObject laserClone = (GameObject)Instantiate(laserBeam, shootPoint.position, shootPoint.rotation);
            laserClone.transform.localScale = -transform.localScale; //if the player is facing left (if x is -1), then x on the local scale of the laser beam is also -1
            anim.SetTrigger("Shoot");
            shootSound.Play();
        }

        if(rb.velocity.x <0) //if we're moving to the left [...]
        {
            transform.localScale = new Vector3(1, 1, 1); // [...] it'll flip the player if we move to the left
        }
        else if(rb.velocity.x >0) //if we're moving to the right [...]
        {
            transform.localScale = new Vector3(-1, 1, 1); // [...] it'll flip the player back to the right
        }
        
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //What absolute does is that if it's a minus then the value is ignored - and it's a plus value
        anim.SetBool("Grounded", isGrounded);
        //anim.SetTrigger("Shoot");
    }
}
