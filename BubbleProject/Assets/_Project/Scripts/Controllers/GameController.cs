using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TimerController timerController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private CanvasGroup p1BubblesBar;
    [SerializeField] private CanvasGroup p2BubblesBar;
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
        int p1_bubble_charges, p2_bubble_charges;
        (p1_bubble_charges, p2_bubble_charges) = this.playerManager.GetBubbles();
        update_bubble_bar(p1_bubble_charges, this.p1BubblesBar);
        update_bubble_bar(p2_bubble_charges, this.p2BubblesBar);
    }

    private void update_bubble_bar(int bubble_charges, CanvasGroup bubble_bar_holder)
    {
        GameObject bubble_bar_enable = null;

        for (int i = 0; i != 4; i++)
        {
            string bar = "bar" + i;
            bubble_bar_enable = bubble_bar_holder.transform.Find(bar).gameObject;
            bubble_bar_enable.SetActive(false);
        }

        Debug.Log(bubble_charges);

        switch (bubble_charges)
        {
            case 0:
                bubble_bar_enable = bubble_bar_holder.transform.Find("bar0").gameObject;
                bubble_bar_enable.SetActive(true);
                break;
            case 1:
                bubble_bar_enable = bubble_bar_holder.transform.Find("bar1").gameObject;
                bubble_bar_enable.SetActive(true);
                break;
            case 2:
                bubble_bar_enable = bubble_bar_holder.transform.Find("bar2").gameObject;
                bubble_bar_enable.SetActive(true);
                break;
            case 3:
                bubble_bar_enable = bubble_bar_holder.transform.Find("bar3").gameObject;
                bubble_bar_enable.SetActive(true);
                break;
        }
    }
}
