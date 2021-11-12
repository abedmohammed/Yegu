using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public PlayerController player;
    private HealthManager healthManager;
    private Fade fade;

    public GameObject deathEffect;

    // Use this for initialization
    public void Start () {

        player = FindObjectOfType<PlayerController>();
        healthManager = FindObjectOfType<HealthManager>();
        fade = FindObjectOfType<Fade>();


    }

    public void RespawnPlayer()
    {

        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        EnemyHealthManager.enemiesKilled = 0;
        SpawnList();
        Instantiate(deathEffect, player.transform.position, transform.rotation);
        player.enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        fade.FadeIn();
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(SceneManager.GetActiveScene().name);

    }

    public GameObject[] MyObjects;

    public void SpawnList()
    {
        foreach (var spawnObject in MyObjects)
        {
            GameObject instanceObject = Instantiate(spawnObject, player.transform.position, transform.rotation) as GameObject;
        }
    }

}
