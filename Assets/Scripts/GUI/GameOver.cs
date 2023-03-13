using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button mainMenuButton;
    public Button quitButton;
    public GameObject gameOverPanel;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(Quit);
        gameOverPanel.SetActive(false);
    }

    public void EndGame()
    {
        gameOverPanel.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
