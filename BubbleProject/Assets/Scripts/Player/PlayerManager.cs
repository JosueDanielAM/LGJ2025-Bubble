using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    private int nextPlayerIndex = 0;

    public void SpawnPlayer(string controlScheme)
    {
        var player = PlayerInput.Instantiate(
            playerPrefab,                     // The prefab to instantiate
            controlScheme: controlScheme,     // Control scheme to use (e.g., "Keyboard1", "Keyboard2")
            pairWithDevice: Keyboard.current  // The device to pair with (optional)
        );
    }
    void Start()
    {
        this.SpawnPlayer("player_1");
        this.SpawnPlayer("player_2"); 
    }
}