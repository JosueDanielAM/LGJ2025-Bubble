using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] private int numPlayer; // Available values are 0 or 2
    [SerializeField] private TextMeshProUGUI textCounter; 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            var playerInput = collider.GetComponent<PlayerInput>();
            Debug.Log($"Player INDEX = {playerInput.playerIndex}");
            if (playerInput == null) 
            { 
                Debug.Log("No player has encoutered the flag.");
                return;
            }
            if (numPlayer != 0 && numPlayer != 2)
            {
                Debug.Log($"Available values of player are 0 or 2, but {numPlayer} was given.");
                return;
            }

            if (playerInput.playerIndex == numPlayer)
            {
                player.AddPoint();
                textCounter.text = (int.Parse(textCounter.text) + 1).ToString();

                Debug.Log($"Player {numPlayer} collected the flag!");
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
