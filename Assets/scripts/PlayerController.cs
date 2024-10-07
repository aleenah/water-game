using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Sprite up, down, left, right;
    float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            rb.velocity = new Vector2(0, speed);
            GetComponent<SpriteRenderer>().sprite = up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            rb.velocity = new Vector2(0, -speed);
            GetComponent<SpriteRenderer>().sprite = down;

        }
        else if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-speed, 0);
            GetComponent<SpriteRenderer>().sprite = left;

        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(speed, 0);
            GetComponent<SpriteRenderer>().sprite = right;

        }
        else {
            rb.velocity = Vector2.zero;
        }
    }
}
