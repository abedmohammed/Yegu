using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public static int playerHealth;
    private LevelManager levelManager;

    public int numOfHearts;

    public bool isDead;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    static public CameraShake instance;

    public GameObject hurtSFX;
    public GameObject deathSFX;

    public float hurtTimer;
    public float maxHurtTimer;


    // Use this for initialization
    void Start () {
        instance = FindObjectOfType<CameraShake>();
        playerHealth = maxPlayerHealth;
        numOfHearts = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && FindObjectOfType<BombManager>().numOfBombs > 0 && playerHealth != 0)
        {
            FindObjectOfType<BombManager>().spawnBomb();
            if (hurtTimer > 0)
            {
                playerHealth += 1;
            }
        }

        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;
        }

        for (int i = 0; i  < hearts.Length; i++)
        {

            if(i < playerHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        if(playerHealth <= 0 && !isDead)
        {
            Instantiate(deathSFX, transform.position, transform.rotation);
            levelManager.RespawnPlayer();
            isDead = true;
        }

		
	}

    public static void hurtPlayer(int damageToGive)
    {

        PlayerController player;
        player = FindObjectOfType<PlayerController>();
        playerHealth -= damageToGive;
        player.FlashPlayer();
        Instantiate(FindObjectOfType<HealthManager>().hurtSFX, player.transform.position, player.transform.rotation);
        FindObjectOfType<HealthManager>().hurtTimer = FindObjectOfType<HealthManager>().maxHurtTimer;

        CameraShake cameraShake;
        cameraShake = FindObjectOfType<CameraShake>();
        instance.StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
    }

}
