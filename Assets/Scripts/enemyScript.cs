using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
    public float speed = 5f;
    float direction = -1f;
    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed * direction, rigidbody2D.velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
            direction *= -1f;
    }
}
