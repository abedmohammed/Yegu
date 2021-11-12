using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Mohammed Abed
    //2019-06-02
    //PlayerController
    //To Move Player

    public float speedMultiplier;

    public Transform shotPosition;
    public GameObject projectile;

    private float timeBetweenShots;
    public float StartTimeBetweenShots;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public GameObject shootSFX;

    // Use this for initialization
    void Start () {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        }

        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPosition.position, shotPosition.rotation);
                Instantiate(shootSFX, shotPosition.position, shotPosition.rotation);
                timeBetweenShots = StartTimeBetweenShots;
            }
        }else
        {
            timeBetweenShots -= Time.deltaTime;
        }


    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += movement * Time.deltaTime * speedMultiplier;
        if(movement.x == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    public void FlashPlayer()
    {

        StartCoroutine("ChangePlayerColour");
    }

    public IEnumerator ChangePlayerColour()
    {
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
}
