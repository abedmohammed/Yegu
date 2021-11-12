using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCommands : MonoBehaviour {

    public CameraShake cameraShake;

    public GameObject spawn;

    public float time = 0.1f;
    public float magnitude = 0.1f;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public GameObject[] Objects;

    public void SpawnList()
    {
        foreach (var spawnObject in Objects)
        {
            GameObject instanceObject = Instantiate(spawnObject, transform.position, transform.rotation) as GameObject;
        }
    }

    public void shakeScreen()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        StartCoroutine(cameraShake.Shake(time, magnitude));
    }

    public void SpawnObject()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }
}
