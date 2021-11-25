using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    [SerializeField]
    private Transform target;
    private Vector3 targetPos;
    private float targetXdir;

    private Vector3 velocity = Vector3.zero;
    private float moveSpeed = .5f;

    [SerializeField]
    private Vector3 offsetPos = new Vector3(7f, 2f, -13f);

    private bool posChanged = false;

    void FixedUpdate(){
        targetXdir = target.gameObject.GetComponent<PlayerMovement>().playerXdir;
        // Checking if the player facing direction and changing camera view according it.
        if(!posChanged && targetXdir<0){
            ChangePos();
        } else if(posChanged && targetXdir>0){
            ChangePos();
        }

        // Setting the actual position for camera to assign
        targetPos = new Vector3(
            target.position.x + offsetPos.x, 
            offsetPos.y, 
            offsetPos.z
        );
        // targetPos += offsetPos;

        // For Smooth transition between player and camera position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveSpeed);
    }

    // To flip the position of camera for player view
    // This will give some space to view whats on their front.
    void ChangePos(){
        posChanged = !posChanged;
        offsetPos.x *= -1;
    }
}