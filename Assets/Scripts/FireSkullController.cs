using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullController : MonoBehaviour {

    public Transform firePoint;
    public Transform firePoint2;

    public GameObject projectile;
    public GameObject projectile2;

    public GameObject shootSFX;

    private float timeBetweenShots;
    public float StartTimeBetweenShots;

    private EnemyHealthManager enemyHealthManager;
    public float spinSpeed;
    public int phase;
    private int oldPhase;


    // Use this for initialization
    void Start () {

        enemyHealthManager = GetComponent<EnemyHealthManager>();
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

        //Phases Moves
        switch (phase)
        {
            case 1:
                firePoint.transform.Rotate(Vector3.forward * spinSpeed);
                firePoint2.transform.Rotate(Vector3.forward * spinSpeed);
                if (timeBetweenShots <= 0)
                {

                    Instantiate(shootSFX, firePoint.position, firePoint.rotation);


                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile2, firePoint.position, firePoint.rotation);


                    timeBetweenShots = StartTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;

            case 2:
                firePoint.transform.Rotate(Vector3.forward * spinSpeed);
                firePoint2.transform.Rotate(Vector3.forward * spinSpeed);
                if (timeBetweenShots <= 0)
                {
                    Instantiate(shootSFX, firePoint.position, firePoint.rotation);


                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile2, firePoint.position, firePoint.rotation);

                    Instantiate(projectile, firePoint2.position, firePoint2.rotation);
                    Instantiate(projectile2, firePoint2.position, firePoint2.rotation);


                    timeBetweenShots = StartTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;

            case 3:
                firePoint.transform.Rotate(Vector3.forward * spinSpeed);
                firePoint2.transform.Rotate(Vector3.forward * spinSpeed);
                if (timeBetweenShots <= 0)
                {
                    Instantiate(shootSFX, firePoint.position, firePoint.rotation);


                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    Instantiate(projectile2, firePoint.position, firePoint.rotation);

                    Instantiate(projectile, firePoint2.position, firePoint2.rotation);
                    Instantiate(projectile2, firePoint2.position, firePoint2.rotation);


                    timeBetweenShots = StartTimeBetweenShots;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime * 2;
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
        } else if(oldPhase == 2)
        {
            phase = 3;
        }

    }

}
