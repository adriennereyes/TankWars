using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button mainMenuButton;
    public Button quitButton;
    public Button playAgainButton;
    public Button restartButton;
    public GameObject gameOverPanel;
    public TextMeshProUGUI winsText;
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;



    private void Start()
    {
        // mainMenuButton.onClick.AddListener(MainMenu);
        // quitButton.onClick.AddListener(Quit);
        // playAgainButton.onClick.AddListener(PlayAgain);
        // restartButton.onClick.AddListener(Restart);
        gameOverPanel.SetActive(false);
    }

    public void EndGame(bool playerOneWonRound, bool playerTwoWonRound, int playerOneWins, int playerTwoWins, int gamesToWin, GameManager gameManager)
    {
        if (playerOneWins >= gamesToWin || playerTwoWins >= gamesToWin)
        {
            Invoke("Stop", 0.5f);
            gameOverPanel.SetActive(true);
            winsText.text = playerOneWonRound ? $"Player 2 wins!" : $"Player 1 wins!";
            playerOneScoreText.text = $"Player 1 Score: {playerOneWins}";
            playerTwoScoreText.text = $"Player 2 Score: {playerTwoWins}";

            playAgainButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            Invoke("Stop", 0.5f);
            gameOverPanel.SetActive(true);
            winsText.text = playerOneWonRound ? $"Player 2 wins!" : $"Player 1 wins!"; playAgainButton.gameObject.SetActive(true);
            playerOneScoreText.text = $"Player 1 Score: {playerOneWins}";
            playerTwoScoreText.text = $"Player 2 Score: {playerTwoWins}";
            restartButton.gameObject.SetActive(true);
        }
    }



    void Stop()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resetScore()
    {
        // Time.timeScale = 1;
        GameData.ResetWins();
        playerOneScoreText.text = $"Player 1 Score: {GameData.playerOneWins}";
        playerTwoScoreText.text = $"Player 2 Score: {GameData.playerTwoWins}";
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayAgain()
    {
        Restart();
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
