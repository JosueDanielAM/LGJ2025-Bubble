using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private const int N_PLAYERS = 2;
    
    [SerializeField] private GameObject player_prefab;
    [SerializeField] private Transform[] spawnPoints;

    private PlayerInput[] players = new PlayerInput[N_PLAYERS];
    private int player_index = 0;
    private int scoreP1;
    private int scoreP2;

    public void SpawnPlayer(string controlScheme, Transform spawnPoint)
    {
        var player = PlayerInput.Instantiate(
            player_prefab,                     // The prefab to instantiate
            controlScheme: controlScheme,     // Control scheme to use (e.g., "Keyboard1", "Keyboard2")
            pairWithDevice: Keyboard.current    // The device to pair with (optional)
        );

        player.transform.position = spawnPoint.position;

        players[player_index++] = player;
    }

    void Start()
    {
        this.SpawnPlayer("player_1", spawnPoints[0]);
        this.SpawnPlayer("player_2", spawnPoints[1]); 
    }

    public void MovePlayersToSpawnPoint() 
    {
        for (int i=0; i < N_PLAYERS; i++)
        {
            players[i].transform.position = spawnPoints[i].position;
        }
    }

    public int GetWinner()
    {
        int highestScore = -1;
        int winnerIndex = -1;

        for (int i = 0; i < N_PLAYERS; i++)
        {
            PlayerMovement playerMovement = players[i].GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                int playerScore = playerMovement.score;
                if (playerScore == highestScore)
                {
                    return -1; // EMPATE
                }
                if (playerScore > highestScore)
                {
                    highestScore = playerScore;
                    winnerIndex = i;
                }
            }
        }

        return winnerIndex;
    }
}