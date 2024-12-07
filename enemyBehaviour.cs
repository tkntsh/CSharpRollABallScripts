using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    //reference to where the player gameobject is
    public Transform player;
    //enemy speed
    public float speed = 1f;

    //update method to move enemy closer to player position per frame
    private void Update()
    {
        if(player != null)
        {
            //moving towards the player gameobject position
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    //method to check collision between gameobjects
    private void OnCollisionEnter(Collision collision)
    {
        //check tag of gameobject
        if(collision.gameObject.CompareTag("Player"))
        {
            //display loser panel when enemy collides with player gameobject
            gameManager.Instance.showLosePanel();
        }
    }
}
