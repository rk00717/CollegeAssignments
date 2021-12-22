// Script Referenced by @Dani yt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour{
    [SerializeField]
    private Transform cameraPos;
    [SerializeField]
    [Range(-1, 0)]
    private float parallaxEffect;
    private float initialPos;
    private float spriteLength;
    [SerializeField]
    private float offsetParam;
    
    void Start(){
        initialPos = cameraPos.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x - offsetParam;
    }

    void Update(){
        float tempPos = cameraPos.position.x * (1 - parallaxEffect);
        float distance = cameraPos.position.x * parallaxEffect;

        transform.position = new Vector3(initialPos + distance, 0f, 0f);

        if(tempPos > initialPos + spriteLength) initialPos += spriteLength;
        else if(tempPos < initialPos - spriteLength) initialPos -= spriteLength;
    }
}