using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovememt : MonoBehaviour {

    Animator anim;
    //Rigidbody rb;
    CharacterController controller;
    public float speed = 2.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Basic WASD Movement
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;

        controller.SimpleMove(moveDirection);

        //Rotate upon changing direction
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
        else if (Input.GetAxis("Vertical") > 0)
        {

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }

        //Moving Animations
        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        //Protect from going off edge of map
        if(transform.position.z > 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
        }
        else if(transform.position.z < -2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
        }

        //If somehow made off of edge of map, Kill player

        //{{TODO}}


    }



}
