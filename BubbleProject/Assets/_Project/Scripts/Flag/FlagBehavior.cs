using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            // Verificar si el jugador es el playerIndex = 0
            var playerInput = collider.GetComponent<PlayerInput>();
            if (playerInput != null && playerInput.playerIndex == 0) // Solo el jugador 1
            {
                Debug.Log("Player 1 collected the flag!");
                player.AddPoint(); 
                Destroy(gameObject); 
            }
            else
            {
                Debug.Log("Only Player 1 can collect the flag.");
            }
        }
    }
}
