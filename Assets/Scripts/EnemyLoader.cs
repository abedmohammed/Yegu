using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour {

    public Transform spawnLocation;

    public GameObject[] enemies;

    public AudioClip[] newTrack;



	// Use this for initialization
	void Start () {
        StartCoroutine(spawnFirstEnemy());
    }
	
	// Update is called once per frame
	void Update ()
    {

		
	}

    public void spawnNextEnemyCO()
    {
        StartCoroutine(spawnNextEnemy());
    }

    public IEnumerator spawnNextEnemy()
    {
        if (enemies.Length > EnemyHealthManager.enemiesKilled)
        {
            yield return new WaitForSeconds(3f);
            if(newTrack[EnemyHealthManager.enemiesKilled] != null)
                FindObjectOfType<MusicTransitions>().ChangeBGM(newTrack[EnemyHealthManager.enemiesKilled]);
            Instantiate(enemies[EnemyHealthManager.enemiesKilled], spawnLocation.position, spawnLocation.rotation);
        }
    }

    public IEnumerator spawnFirstEnemy()
    {
        yield return new WaitForSeconds(3f);
        if (newTrack[EnemyHealthManager.enemiesKilled] != null)
            FindObjectOfType<MusicTransitions>().ChangeBGM(newTrack[EnemyHealthManager.enemiesKilled]);
        Instantiate(enemies[EnemyHealthManager.enemiesKilled], spawnLocation.position, spawnLocation.rotation);
    }

}
