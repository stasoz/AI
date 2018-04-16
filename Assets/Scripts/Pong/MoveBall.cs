using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

    Vector3 startPos;
    Rigidbody2D rb;
    float speed = 400;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startPos = this.transform.position;
        ResetBall();
    }
    public void ResetBall()
    {
        this.transform.position = startPos;
        rb.velocity = Vector3.zero;
        Vector3 dir = new Vector3(Random.RandomRange(100, 300), Random.RandomRange(-100, 100), 0).normalized;
        rb.AddForce(dir * speed);
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetBall();
        }
    }
}
