using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Animator animator;

    public void Start()
    {

        animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void FadeIn()
    {
        animator.SetTrigger("FadeOut");
    }

}
