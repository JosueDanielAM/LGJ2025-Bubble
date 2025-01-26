using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup tutorialPanel;
    [SerializeField] private CanvasGroup creditsPanel;
    [SerializeField] private float fadeDuration = 1.0f;

    public void PlayGame()
    {
        StartCoroutine(ShowTutorialAndStartGame());
    }

    public void ShowTutorial()
    {
        tutorialPanel.alpha = 1.0f;
        tutorialPanel.blocksRaycasts = true; 
        tutorialPanel.interactable = true;   
    }

    public void HideTutorial()
    {
        tutorialPanel.alpha = 0.0f;          
        tutorialPanel.blocksRaycasts = false; 
        tutorialPanel.interactable = false;  
    }

    private IEnumerator ShowTutorialAndStartGame()
    {
        yield return StartCoroutine(FadeCanvasGroup(tutorialPanel, 0, 1, fadeDuration));
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(FadeCanvasGroup(tutorialPanel, 1, 0, fadeDuration));

        // Cargar la escena del juego
        SceneManager.LoadSceneAsync("VSArena");
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0;

        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = startAlpha > endAlpha;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null; // Esperar al siguiente frame
        }

        canvasGroup.alpha = endAlpha;

        canvasGroup.blocksRaycasts = endAlpha > 0;
        canvasGroup.interactable = endAlpha > 0;
    }

    public void Credits()
    {
        creditsPanel.alpha = 1.0f;
        creditsPanel.blocksRaycasts = true;
    }

    public void Back(string panel)
    {
        if (panel == "Credits")
        {
            creditsPanel.alpha = 0f;
            creditsPanel.blocksRaycasts = false;
        }
        else
        {
            Debug.Log("Back button not working for `" + panel + "` panel");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game is shutting down");
        Application.Quit();
    }
}
