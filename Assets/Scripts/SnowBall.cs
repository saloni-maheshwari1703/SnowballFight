using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float speed;
    public GameObject snowballEffect;
    //private GameManager GameManager;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
        //GameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(speed * transform.localScale.x,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            FindObjectOfType<GameManager>().HurtP1();
            //GameManager.HurtP1();
        }
        if (collision.CompareTag("Player2"))
        {
            FindObjectOfType<GameManager>().HurtP2();
            //GameManager.HurtP2();
        }
        Instantiate(snowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
