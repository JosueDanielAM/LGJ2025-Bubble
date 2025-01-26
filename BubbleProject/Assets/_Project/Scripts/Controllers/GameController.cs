using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TimerController timerController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private WinMenuController winMenuController;

    private void Awake()
    {
        TimerController.OnEndState += TimerController_OnEndState;
    }

    private void TimerController_OnEndState()
    {
        int playerIndex = playerManager.GetWinner();

        Debug.Log($"Player index {playerIndex}");
        if (playerIndex == 0) // pop P1 WIN
        {
            Debug.Log("ENTRE P1");
            winMenuController.EnablePanel("P1");
        } else if (playerIndex == 1) // pop P2 WIN
        {
            Debug.Log("ENTRE P2");
            winMenuController.EnablePanel("P2");
        } else // empate
        {
            Debug.Log("ENTRE EMPATE");
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        winMenuController.DisablePanel();
    }

    void Update()
    {
        
    }


}
