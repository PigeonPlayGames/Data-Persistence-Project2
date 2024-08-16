using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField playerNameInput; // Input field for entering the player's name
    public Text bestScoreText; // Text field to display the highest score

    void Start()
    {
        LoadBestScore(); // Load the highest score when the game starts
    }

    public void StartGame()
    {
        // Save the player's name to PlayerPrefs for use in the game scene
        if (playerNameInput != null)
        {
            PlayerPrefs.SetString("CurrentPlayerName", playerNameInput.text);
        }
        else
        {
            Debug.LogError("playerNameInput is not assigned in MenuManager!");
        }

        // Load the game scene (index 1 in the build settings)
        SceneManager.LoadScene(1);
    }

    public void LoadBestScore()
    {
        if (bestScoreText != null)
        {
            if (MainGameManager.Instance != null)
            {
                bestScoreText.text = "Best Score: " + MainGameManager.Instance.bestScore + " Name: " + MainGameManager.Instance.playerName;
            }
            else
            {
                Debug.LogError("MainGameManager.Instance is null in MenuManager.LoadBestScore()");
                bestScoreText.text = "Best Score: N/A Name: N/A";
            }
        }
        else
        {
            Debug.LogError("bestScoreText is not assigned in MenuManager!");
        }
    }

    public void Quit()
    {
        // Quit the application
        Application.Quit();
    }
}
