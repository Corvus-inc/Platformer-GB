using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool jump;

    public GameObject bullet;
    public float maxSpeed;
    public float moveForce;
    public float jumpForce;

    private bool facingRight;
    private Transform groundCheck;
    private bool grounded = false;

    private void Start()
    {
        groundCheck = transform.Find("groundCheck");

    }
    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            Debug.Log("JumpPlayer");
        }
        if (Input.GetMouseButtonDown(0))
        {
            var fire = Instantiate<GameObject>(bullet, gameObject.transform.position, transform.rotation);
            fire.transform.localScale = transform.localScale;
            Debug.Log("Стреляю");
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0 && h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
                Debug.Log(Input.GetAxis("Horizontal"));
        }
        //if (Math.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(Math.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //}
        if (h < 0 && !facingRight)
        {
            Flip();
        }
        else if (h > 0 && facingRight)
        {
            Flip();
        }
        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
