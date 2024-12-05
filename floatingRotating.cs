using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingRotating : MonoBehaviour
{
    //objects needed to keep objects rotating and floating
    public float rotationSpeed = 50f; 
    public float floatSpeed = 1f;
    public float floatAmplitude = 0.5f;

    //getting initial position of object and offsetting
    private Vector3 startPosition;
    private float randomOffset;

    //storing start position of object
    private void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        //object rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        //floating with random offset
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
