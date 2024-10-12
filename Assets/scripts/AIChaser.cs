using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaser : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    public float threshold = 8.0f; 
    public float speed = 1.0f; 

    AIHelper.State state = AIHelper.State.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == AIHelper.State.IDLE) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= threshold) {
                state = AIHelper.State.ATTACKING;
            } 
        } 
        else if (state == AIHelper.State.ATTACKING) {
                var direction = player.transform.position - transform.position;
                direction = direction.normalized;
                rb.velocity = direction * speed;
        }
        
    }
}
