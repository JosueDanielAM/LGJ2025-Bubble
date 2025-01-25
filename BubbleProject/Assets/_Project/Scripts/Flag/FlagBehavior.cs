using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("Flag collected!");
            player.AddPoint();
            Destroy(gameObject);
        }
    }
}
