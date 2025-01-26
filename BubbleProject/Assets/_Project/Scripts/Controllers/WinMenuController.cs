using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup p1CounterHolder;
    [SerializeField] private CanvasGroup p2CounterHolder;
    [SerializeField] private CanvasGroup p1BubbleHolder;
    [SerializeField] private CanvasGroup p2BubbleHolder;
    [SerializeField] private CanvasGroup timeHolder;
    [SerializeField] private GameObject p1WinMenu;
    [SerializeField] private GameObject p2WinMenu;

    public void EnablePanel(string player)
    {
        Time.timeScale = 0.0f; // pausa el tiempo

        timeHolder.alpha = 0f;
        timeHolder.blocksRaycasts = false;
        if (player == "P1")
        {
            p1CounterHolder.alpha = 0f;
            p1CounterHolder.blocksRaycasts = false;
            p1WinMenu.SetActive(true);
        }
        if (player == "P2")
        {
            p2CounterHolder.alpha = 0f;
            p2CounterHolder.blocksRaycasts = false;
            p2WinMenu.SetActive(true);
        }
    }

    public void DisablePanel()
    {
        p1WinMenu.SetActive(false);
        p2WinMenu.SetActive(false);

        timeHolder.alpha = 1f;
        timeHolder.blocksRaycasts = true;
        p1CounterHolder.alpha = 1f;
        p1CounterHolder.blocksRaycasts = true;
        p2CounterHolder.alpha = 1f;
        p2CounterHolder.blocksRaycasts = true;

        p1BubbleHolder.alpha = 1f;
        p1BubbleHolder.blocksRaycasts = true;
        p2BubbleHolder.alpha = 1f;
        p2BubbleHolder.blocksRaycasts = true;
    }

    public void Menu()
    {
        Debug.Log("Return to Main Menu scene");
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        Debug.Log("Reload VSArena scene");
        SceneManager.LoadScene("VSArena");
    }
}
