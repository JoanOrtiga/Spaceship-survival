using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Material mt;

    public float Speed = 2f;
    Vector2 offset;


    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;

        offset = mt.mainTextureOffset;
    }

    
    void Update()
    {
        offset.y += Time.deltaTime / Speed;

        mt.mainTextureOffset = offset;
    }
}
