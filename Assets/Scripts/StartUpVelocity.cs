using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpVelocity : MonoBehaviour {

    public float minRandom = -10f;
    public float maxRandom = 10f;

    private Rigidbody2D myrigidbody2D;

    void Start()
    {

        myrigidbody2D = GetComponent<Rigidbody2D>();

        myrigidbody2D.velocity = new Vector2(Random.Range(minRandom, maxRandom), Random.Range(minRandom, maxRandom));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
