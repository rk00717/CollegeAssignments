using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour{
    private GameObject currentObject;
    private Rigidbody2D currentObjectbody;
    private Transform currentObjectPos;

    [SerializeField]
    private Transform cameraPos;
    [SerializeField]
    private PlayerMovement playerIP;

    [SerializeField]
    private GameObject imagePrefab;
    [SerializeField]
    private Vector3 imagePosition = Vector3.zero;

    private List<GameObject> prefabs = new List<GameObject>();

    [SerializeField]
    private float invisOffset = -20f;
    [SerializeField]
    private float spwanOffset = 17.9f;

    [SerializeField]
    private float newInvisOffset;
    [SerializeField]
    private float newSpwanOffset;
    [SerializeField]
    private int maxLimit = 3;
    [SerializeField]
    private float moveSpeed = 5f;

    void Start(){
        // imagePrefab = (GameObject)Resources.Load("Prefabs/Main_Background", typeof(GameObject));
        for(int i = 0; i < maxLimit; i++){
            SpwanImage(spwanOffset*i);
        }
    }

    void FixedUpdate(){
        for(int i=0; i<prefabs.Count; i++){
            currentObject = prefabs[i];

            currentObjectPos = currentObject.GetComponent<Transform>();
            currentObjectbody = currentObject.GetComponent<Rigidbody2D>();

            if(playerIP.playerXdir>0){
                // newInvisOffset = invisOffset + cameraPos.position.x;
                // newSpwanOffset = spwanOffset + cameraPos.position.x;
                
                // currentObjectbody.velocity = Vector3.left*moveSpeed*playerIP.playerXdir;
                currentObjectbody.velocity = new Vector2(moveSpeed*playerIP.playerXdir, 0f);

                if(currentObjectPos.position.x <= invisOffset + cameraPos.position.x){
                    imagePosition.x = transform.position.x + (spwanOffset * (prefabs.Count-1));
                    currentObjectPos.position = imagePosition;
                    prefabs.RemoveAt(i);
                    prefabs.Add(currentObject);
                }
            }
            if(playerIP.playerXdir<0){
                // newInvisOffset = spwanOffset + cameraPos.position.x;
                // newSpwanOffset = invisOffset + cameraPos.position.x;

                // currentObjectbody.velocity = Vector3.right*moveSpeed*playerIP.playerXdir;
                currentObjectbody.velocity = new Vector2(moveSpeed*playerIP.playerXdir, 0f);

                if(currentObjectPos.position.x >= spwanOffset + cameraPos.position.x){
                    // imagePosition.x = transform.position.x + newSpwanOffset;
                    imagePosition.x = transform.position.x + (invisOffset * (prefabs.Count-1));
                    currentObjectPos.position = imagePosition;
                    prefabs.RemoveAt(i);
                    prefabs.Add(currentObject);
                }
            }
            if(playerIP.playerXdir == 0){
                currentObjectbody.velocity = Vector3.zero;
            }
        }

    }

    void SpwanImage(float offset = 0f){
        imagePosition.x = transform.position.x + offset;
        prefabs.Add(Instantiate(imagePrefab, imagePosition, Quaternion.identity, this.transform));
    }
}
