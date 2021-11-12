using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            StartCoroutine("nextLevel");

        }
	}


    public IEnumerator nextLevel()
    {

        FindObjectOfType<Fade>().FadeIn();
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(Application.loadedLevel + 1);

    }
}
