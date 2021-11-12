using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour {

    public Transform firePoint;

    public GameObject projectile;

    private EnemyHealthManager enemyHealthManager;
    public int phase;
    private int oldPhase;
    private PlayerController player;
    public GameObject moonBeam;

    private Transform beamPosition;
    private float timeBetweenShots;
    public float StartTimeBetweenShots;

    // Use this for initialization
    void Start () {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
        player = FindObjectOfType<PlayerController>();
        timeBetweenShots = StartTimeBetweenShots;
        phase = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Phase Selection
        if (enemyHealthManager.enemyHealth > enemyHealthManager.maxEnemyhealth * 0.7 && enemyHealthManager.enemyHealth < enemyHealthManager.maxEnemyhealth * 0.99 && phase == 0)
        {
            StartCoroutine("ChangePhase");
        }
        else if (enemyHealthManager.enemyHealth > enemyHealthManager.maxEnemyhealth * 0.4 && enemyHealthManager.enemyHealth < enemyHealthManager.maxEnemyhealth * 0.7 && phase == 1)
        {
            StartCoroutine("ChangePhase");
        }
        else if (enemyHealthManager.enemyHealth < enemyHealthManager.maxEnemyhealth * 0.4 && phase == 2)
        {
            StartCoroutine("ChangePhase");
        }

        switch (phase)
        {
            case 1:
                if (timeBetweenShots <= 0)
                {
                    
                    Instantiate(moonBeam, new Vector3(player.transform.position.x + Random.Range(-2, 2), player.transform.position.y, player.transform.position.z), player.transform.rotation);


                    timeBetweenShots = StartTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;
            case 2:
                if (timeBetweenShots <= 0)
                {
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);


                    timeBetweenShots = StartTimeBetweenShots/5;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;
            case 3:
                if (timeBetweenShots <= 0)
                {
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(moonBeam, new Vector3(player.transform.position.x + Random.Range(-2, 2), player.transform.position.y, player.transform.position.z), player.transform.rotation);


                    timeBetweenShots = StartTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;
        }

    }

    public IEnumerator ChangePhase()
    {
        oldPhase = phase;
        phase = 0;
        GetComponent<Animator>().SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("Attack", false);
        if (oldPhase == 0)
        {
            phase = 1;
        }
        else if (oldPhase == 1)
        {
            phase = 2;
        }
        else if (oldPhase == 2)
        {
            phase = 3;
        }

    }
}
