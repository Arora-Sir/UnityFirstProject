using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    //public float forceMult = 200;
    //private Rigidbody2D rb;

    //   private void Start()
    //   {
    //     rb = GetComponent<Rigidbody2D>();
    //   }

    //   void Update()
    //   {

    //       if(Input.GetKey(KeyCode.D))
    //       {
    //           rb.velocity = Time.deltaTime * new Vector3(1000,0,0);
    //       }
    //       if (Input.GetKey(KeyCode.A))
    //       {
    //           rb.velocity = Time.deltaTime * new Vector3(-1000, 0, 0);
    //       }
    //       if (Input.GetKey(KeyCode.Space))
    //       {
    //           rb.velocity = Time.deltaTime * new Vector3(0, 2000, 0);
    //       }
    //       if (Input.GetKey(KeyCode.S))
    //       {
    //           rb.velocity = Time.deltaTime * new Vector3(0, 0, -1000);
    //       }
    //   }

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 50f;

    float horizontalMove = 5f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        //Debug.Log(Input.GetAxisRaw("Horizontal") * speed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            //animator.SetBool("IsCrouching", true);

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            //animator.SetBool("IsCrouching", false);

        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
