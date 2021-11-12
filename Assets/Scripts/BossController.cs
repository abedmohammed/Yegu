using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Transform firePoint;

    public Transform rotPoint1;
    public Transform rotPoint2;
    public Transform rotPoint3;
    public Transform rotPoint4;

    public GameObject projectile;

    public GameObject bone;

    public GameObject projectile1;
    public GameObject projectile2;

    private EnemyHealthManager enemyHealthManager;
    public int phase;
    private int oldPhase;
    private PlayerController player;
    public GameObject bossBeam;

    public float spinSpeed;
    private Transform beamPosition;
    private float timeBetweenShots;
    public float StartTimeBetweenShots;

    // Use this for initialization
    void Start()
    {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
        player = FindObjectOfType<PlayerController>();
        timeBetweenShots = StartTimeBetweenShots;
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            case 2:
                if (timeBetweenShots <= 0)
                {
                    Instantiate(bossBeam, firePoint.transform.position, firePoint.transform.rotation);
                    timeBetweenShots = StartTimeBetweenShots / 2;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;
            case 1:
                rotPoint1.transform.Rotate(Vector3.forward * spinSpeed);
                rotPoint2.transform.Rotate(Vector3.forward * spinSpeed);
                rotPoint3.transform.Rotate(Vector3.forward * spinSpeed);
                rotPoint4.transform.Rotate(Vector3.forward * spinSpeed);
                if (timeBetweenShots <= 0)
                {
                    Instantiate(projectile1, rotPoint1.position, rotPoint1.rotation);
                    Instantiate(projectile2, rotPoint1.position, rotPoint1.rotation);

                    Instantiate(projectile1, rotPoint2.position, rotPoint2.rotation);
                    Instantiate(projectile2, rotPoint2.position, rotPoint2.rotation);

                    Instantiate(projectile1, rotPoint3.position, rotPoint3.rotation);
                    Instantiate(projectile2, rotPoint3.position, rotPoint3.rotation);

                    Instantiate(projectile1, rotPoint4.position, rotPoint4.rotation);
                    Instantiate(projectile2, rotPoint4.position, rotPoint4.rotation);

                    timeBetweenShots = StartTimeBetweenShots / 10 ;
                }
                else
                {
                    timeBetweenShots -= Time.deltaTime;
                }
                break;
            case 3:
                if (timeBetweenShots <= 0)
                {
                    Instantiate(bone, new Vector2(firePoint.transform.position.x + Random.Range(-20, 20), firePoint.transform.position.y + 10), firePoint.rotation);
                    Instantiate(bone, new Vector2(firePoint.transform.position.x + Random.Range(-20, 20), firePoint.transform.position.y + 10), firePoint.rotation);
                    Instantiate(bone, new Vector2(firePoint.transform.position.x + Random.Range(-20, 20), firePoint.transform.position.y + 10), firePoint.rotation);

                    timeBetweenShots = StartTimeBetweenShots/20;
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
