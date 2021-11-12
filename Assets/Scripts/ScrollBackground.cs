using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public float parralaxX;
    public float parralaxY;

    public Vector2 offset;

    // Update is called once per frame
    void Update()
    {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        offset = mat.mainTextureOffset;

        offset.y += Time.deltaTime / parralaxY;
        offset.x += Time.deltaTime / parralaxX;

        mat.mainTextureOffset = offset;
    }
}
