using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class PauseManager : MonoBehaviour
{
    public bool panelOpened = false;
    public CameraLook cameraLook;
    
    public void Start()
    {
        UnPauseGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cameraLook.sensitivity = new Vector2(0, 0);
    }
    public void UnPauseGame()
    {
        if (!panelOpened)
        {
            Debug.Log("normal time");
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cameraLook.sensitivity = new Vector2(1, 1);
        }
    }
}
