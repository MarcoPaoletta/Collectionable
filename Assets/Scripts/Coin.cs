using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;

    private bool generateNewPosition;

    void OnTriggerEnter2D(Collider2D coin)
    {
        generateNewPosition = true;
    }

    void Start()
    {
        if(generateNewPosition) // if the coin collided with another coin or the player
        {
            transform.position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f)); // change the position again
        }
    }

}
