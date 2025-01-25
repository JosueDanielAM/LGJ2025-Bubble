using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player_prefab;

    [SerializeField]
    private Transform[] spawnPoints;

    public void SpawnPlayer(string controlScheme, Transform spawnPoint)
    {
        var player = PlayerInput.Instantiate(
            player_prefab,                     // The prefab to instantiate
            controlScheme: controlScheme,     // Control scheme to use (e.g., "Keyboard1", "Keyboard2")
            pairWithDevice: Keyboard.current    // The device to pair with (optional)
        );

        player.transform.position = spawnPoint.position;
    }
    void Start()
    {
        this.SpawnPlayer("player_1", spawnPoints[0]);
        this.SpawnPlayer("player_2", spawnPoints[1]); 
    }
}