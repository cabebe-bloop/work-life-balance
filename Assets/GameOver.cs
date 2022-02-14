using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Player player;

    public Image gameOverBackground;

    void Update()
    {
        if (player.gameOver)
        {
            gameOverBackground.enabled = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
