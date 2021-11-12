using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {

    public Image[] bombs;

    public int numOfBombs;
    public GameObject bomb;
    public Transform explosionLocation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        for (int i = 0; i < bombs.Length; i++)
        {

            if (i < numOfBombs)
            {
                bombs[i].enabled = true;
            }
            else
            {
                bombs[i].enabled = false;
            }
        }
    }

    public void spawnBomb()
    {
        numOfBombs -= 1;
        Instantiate(bomb, explosionLocation.position, explosionLocation.rotation);
    }
}
