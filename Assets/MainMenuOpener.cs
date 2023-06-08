using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuOpener : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!panel.activeInHierarchy)
            {
                OpenMenu();
                panel.SetActive(true);
            }
            else
            {
                CloseMenu();
                panel.SetActive(false);
            }
        }
    }
    public void CloseMenu()
    {
        panel.SetActive(false);
        pauseManager.UnPauseGame();
    }
    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}
