using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] private int numPlayer; // Available values are 1 or 2

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            var playerInput = collider.GetComponent<PlayerInput>();
            if (playerInput == null) 
            { 
                Debug.Log("No player has encoutered the flag.");
                return;
            }
            if (numPlayer != 1 && numPlayer != 2)
            {
                Debug.Log($"Available values of player are 1 or 2, but {numPlayer} was given.");
                return;
            }

            if (playerInput.playerIndex == numPlayer - 1)
            {
                Debug.Log($"Player {numPlayer} collected the flag!");
                player.AddPoint();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"WARN: Only the player {numPlayer} can take this flag {this.gameObject.name}.");
                return;
            }
        }
    }
}
