using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    public void OpenPanel()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
        pauseManager.panelOpened = true;
    }
    public void ClosePanel()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
        pauseManager.panelOpened = false;
    }

}
