using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {

	// Use this for initialization

    public float speed;
    public float height;
    private Rigidbody2D rb;
    public float moveX;
    public float moveY;
    public bool facingRight = true;
    //get components up here, use variable
    private Animator _animator;
    private bool collided;
    private float timer = 0.0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("check2");
        if (collision.gameObject.name == "Tilemap")
        {
            collided = true;
            _animator.SetBool("isJumping", false);
            Debug.Log("touching");
        }
    }


    void Start()
    {
        Debug.Log("check");
        _animator = GetComponent<Animator>();
    }
    
    
  

    void Update ()
    {
        PlayerMove();
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            _animator.SetBool("isJumping", false);
        }
        
        
    }
    void PlayerMove()
    {
        ////controls
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") > 0.5f)
        {
            _animator.SetBool("isJumping", Mathf.Abs(moveY) > 0.5f);
            Jump();
        }
        //player direction
        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if(moveX >0.0f && facingRight== true)
        {
            FlipPlayer();
        }
        //animation
        _animator.SetBool("isMoving", Mathf.Abs(moveX) > 0.5f);
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        if (collided == false)
        {
            Debug.Log("not grounded");
            return;
        }
        if(collided == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * height, ForceMode2D.Impulse);
            _animator.SetBool("isJumping", Mathf.Abs(moveY) > 0.0f);
            collided = false;
        }
       
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}

