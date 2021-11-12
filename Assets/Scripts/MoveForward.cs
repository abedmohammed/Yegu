using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float maxTimer;
    private float timer;
    private Rigidbody2D rb;

    public int speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, speed);
        timer = maxTimer;
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

	}
}
