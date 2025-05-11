using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Presentacion");
    }
    public void LoadEvaluation()
    {
        gameManager.Instance.LoadEvaluation();
    }
    public void LoadNextDay()
    {
        gameManager.Instance.LoadNextDay();
    }
}
