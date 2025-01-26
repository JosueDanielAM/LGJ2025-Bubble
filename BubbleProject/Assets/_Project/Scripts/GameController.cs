using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TimerController timerController;
    [SerializeField] private PlayerManager playerManager;

    private void Awake()
    {
        TimerController.OnEndState += TimerController_OnEndState;
    }

    private void TimerController_OnEndState()
    {
        int playerIndex = playerManager.GetWinner();

        if (playerIndex == 0) // pop P1 WIN
        {

        } else if (playerIndex == 2) // pop P2 WIN
        {

        } else // empate
        {

        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        
    }


}
