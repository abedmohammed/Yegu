using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int maxEnemyhealth;
    public int enemyHealth;

    public int bombDamage;

    public static int enemiesKilled;
    private bool spawned = false;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public AudioClip winSong;

    // Use this for initialization
    void Start () {

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        enemyHealth = maxEnemyhealth;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1) && FindObjectOfType<BombManager>().numOfBombs > 0 && HealthManager.playerHealth != 0)
        {
            enemyHealth -= bombDamage;
        }

        if (enemyHealth <= 0)
        {
            if (name == "Final Boss(Clone)")
            {
                GetComponent<Animator>().Play("DeathAnimation");
                StartCoroutine("win");
            } else
            {
                GetComponent<Animator>().Play("DeathAnimation");
                if (!spawned)
                {
                    enemiesKilled += 1;
                    FindObjectOfType<EnemyLoader>().spawnNextEnemyCO();
                    spawned = true;
                }
            }



        }
	}

    public void giveDamage(int damageToGive)
    {
        StartCoroutine("ChangeEnemyColour");
        enemyHealth -= damageToGive;      
    }

    public IEnumerator ChangeEnemyColour()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
        yield return new WaitForSeconds(.1f);
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }

    public IEnumerator win()
    {
        yield return new WaitForSeconds(4f);
        FindObjectOfType<Fade>().FadeIn();
        if (winSong != null)
            FindObjectOfType<MusicTransitions>().ChangeBGM(winSong);
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(Application.loadedLevel + 1);

    }
}
