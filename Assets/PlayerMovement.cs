/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float movementSpeed = 3f;//Movement Speed of the Player
    private Vector2 movement;
    private Rigidbody2D rigidbody;

    private Animator anim;
    private float horizontal=0.0f;
    private float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        horizontal = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
        speed = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
        

        if(movement.x < -0.01f) //walk side animation - flip horizontal , for left direction
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
        }
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", speed);



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * movementSpeed * Time.fixedDeltaTime);
    }

}
*/
