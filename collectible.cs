using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    //points user accumulates upon collecting collectible
    public int pointValue = 10;

    //method for when player runs into a collectible gameobject
    private void OnTriggerEnter(Collider other)
    {
        //checking object tag to add points and destory gameobject
        if(other.CompareTag("Player"))
        {
            gameManager.Instance.addScore(pointValue);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
