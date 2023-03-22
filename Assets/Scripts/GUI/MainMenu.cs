using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject highScorePanel;
    public TextMeshProUGUI highScoreText;
    public AudioClip musicClip;
    private AudioSource audioSource;


    private void Start()
    {
        highScorePanel.SetActive(false);
        highScoreText.text = $"Player 1 Wins: {GameData.playerOneTotalWins}\nPlayer 2 Wins: {GameData.playerTwoTotalWins}";

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void Play()
    {
        audioSource.Stop();
        SceneManager.LoadScene("Game 1");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetScores()
    {
        GameData.ResetTotalWins();
        highScoreText.text = $"Player 1 Wins: {GameData.playerOneTotalWins}\nPlayer 2 Wins: {GameData.playerTwoTotalWins}";
    }

    public void HighScores()
    {
        if (GameData.playerOneTotalWins >= GameData.playerTwoTotalWins)
        {
            highScoreText.text = $"Player 1 Wins: {GameData.playerOneTotalWins}\nPlayer 2 Wins: {GameData.playerTwoTotalWins}";
        }
        else
        {
            highScoreText.text = $"Player 2 Wins: {GameData.playerTwoTotalWins}\nPlayer 1 Wins: {GameData.playerOneTotalWins}";
        }
        highScorePanel.SetActive(true);
    }

    public void backToMainMenu()
    {
        highScorePanel.SetActive(false);
    }
}
