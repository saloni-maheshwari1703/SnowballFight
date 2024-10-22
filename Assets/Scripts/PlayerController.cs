using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject snowBall;
    //public Transform throwPoint;

    //public Transform GroundCheck;
    //public bool isGrounded;
    //public float GroundCheckRadius;
    //public LayerMask whatIsGround;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Throw;
    public KeyCode Jump;

    private Rigidbody2D rigidbody2D;
    private Animator anim;

    public AudioSource throwSound;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(GroundCheck.position,GroundCheckRadius,whatIsGround);
        //if(transform.position.y <= -4 || transform.position.y >= -0.5 || transform.position.y >= 1.8)
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}
        if (Input.GetKey(Left))
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(Right))
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyDown(Throw))
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall,transform.position + new Vector3(transform.localScale.x,0,0),Quaternion.identity);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            throwSound.Play();
        }

        if (Input.GetKeyDown(Jump) /*&& isGrounded*/)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);

        }

        anim.SetFloat("Speed",Mathf.Abs(rigidbody2D.velocity.x));
        //anim.SetBool("Ground", isGrounded);
    }
}
