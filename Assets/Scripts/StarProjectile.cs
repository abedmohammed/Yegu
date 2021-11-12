using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : MonoBehaviour {

    public float speed;
    public float speedMultiplyer;
    public PlayerController player;

    public int damage;
    private Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();


        playerPos = new Vector3(player.transform.position.x + Random.Range(-2, 2), player.transform.position.y, player.transform.position.z);

        Vector3 difference = playerPos - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        speed += speed * speedMultiplyer;

        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Yegu")
        {
            HealthManager.hurtPlayer(damage);
        }

        Destroy(gameObject);
    }
}
