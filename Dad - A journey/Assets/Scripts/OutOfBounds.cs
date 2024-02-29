using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject player;
    public Transform respawnLocation;

    private void Start()
    {
        respawnLocation = GetComponentInChildren<Transform>().Find("respawnLocation");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.Translate(respawnLocation.position);
        }
    }
}
