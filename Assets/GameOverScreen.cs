using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public int points = 0;

    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = points.ToString() + "  POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("City");
    }

    public void ExitButton()
    {
        //SceneManager.LoadScene("MainMenu");
    }
    public void AddPoints(int point)
    {
        points = points + point;
    }
}
