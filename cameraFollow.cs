using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //refering player gameobject and camera offset
    public Transform player;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    public float smoothSpeed = 0.125f;

    //method to update per second frame for the game to follow the player
    private void LateUpdate()
    {
        //position of the camera
        Vector3 desiredPosition = player.position + offset;
        
        //smooth transition to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //ensuring camera is always looking at the player
        transform.LookAt(player);
    }
}
