﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class characterController : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jumpForce = 100f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float score;
    public float move;
    private Rigidbody2D rigidbody2D;
    public float spawnX, spawnY;
    public float starX, starY;
    public int star_counter;
    public int lives;
    GameObject star;
    GameObject c;

    // Use this for initialization
    void Start()
    {
        lives = 3;
        spawnX = transform.position.x;
        spawnY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

    }

    void Update()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {

            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();



        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "star")
        {
            score++;
            star_counter++; //увеличить счетчик звезд
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.name == "dieCollider") || (col.gameObject.name == "saw") || (col.gameObject.name == "enemy"))
        {
            lives--;
            if (lives > 0)
            {
                //спавн героя в точке старта уровня
                transform.position = new Vector3(spawnX, spawnY, transform.position.z);

                //вернуть все звезды на уровне
                /*for (int i = 0; i < star_counter; i++)
                {
                    c = (GameObject)Instantiate(star, transform.position, transform.rotation);
                }*/
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "scene1")
                    SceneManager.LoadScene("scene1"); //заново загрузить сцену
                else
                    SceneManager.LoadScene("scene2"); //заново загрузить сцену}
            }
        }

        if (col.gameObject.name == "endLevel")
        {
            if (!(GameObject.Find("star")))
                SceneManager.LoadScene("scene2");

        }
        else if (col.gameObject.name == "endLevel2")
        {
            if (!(GameObject.Find("star")))
            {
                //SceneManager.LoadScene("scene1");
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 300), "Menu");
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 25), "Reload Game"))
                {
                    Application.LoadLevel("scene1");
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Settings"))
                {
                    //Application.LoadLevel("Game");
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 25), "Exit"))
                {
                    Application.Quit();
                }
            }


        }
    }



    /*void OnTriggerEnter2D(Collider2D col){
        if ((col.gameObject.name == "dieCollider") || (col.gameObject.name == "saw"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

	    if (col.gameObject.name == "star")
        {
						score++;
						Destroy (col.gameObject);
		}

		if (col.gameObject.name == "endLevel")
        {
			if (!(GameObject.Find("star"))) Application.LoadLevel ("scene2");

		}
	}*/

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Stars: " + score + "\nLives: " + lives);
    }
}
