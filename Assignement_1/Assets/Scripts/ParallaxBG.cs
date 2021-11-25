using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour{
    [SerializeField]
    private Transform cameraPos;
    [SerializeField]
    [Range(0, 1)]
    private float parallaxEffect;
    private float initialPos;
    private float spriteLength;
    [SerializeField]
    private float offsetParam;
    
    void Start(){
        parallaxEffect *= -1;
        initialPos = cameraPos.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x - offsetParam;
    }

    void Update(){
        float tempPos = cameraPos.position.x * (1 - parallaxEffect);
        float distance = cameraPos.position.x * parallaxEffect;

        transform.position = new Vector3(initialPos + distance, 0f, 0f);

        // if(cameraPos.position.x > transform.position.x + spriteLength) initialPos += spriteLength;
        // else if(cameraPos.position.x < transform.position.x - spriteLength) initialPos -= spriteLength;

        if(tempPos > initialPos + spriteLength) initialPos += spriteLength;
        else if(tempPos < initialPos - spriteLength) initialPos -= spriteLength;
    }
}