using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Flip : MonoBehaviour
{
    private Rigidbody2D rb; //declares variable to give the player gravity and the ability to interact with physics
    private Animator anim; //making a reference to the animator which is attached to the player
    public bool isGrounded; //it's either true or false if the player is on the ground

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0) //if we're moving to the left [...]
        {
            transform.localScale = new Vector3(1, 1, 1); // [...] it'll flip the player if we move to the left
        }
        else if (rb.velocity.x > 0) //if we're moving to the right [...]
        {
            transform.localScale = new Vector3(-1, 1, 1); // [...] it'll flip the player back to the right
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //What absolute does is that if it's a minus then the value is ignored - and it's a plus value
        anim.SetBool("Grounded", isGrounded);
    }
}
