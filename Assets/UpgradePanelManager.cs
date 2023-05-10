using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class UpgradePanelManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    [SerializeField] GameObject panel;
    PauseManager pauseManager;
    [SerializeField] List<UpgradeButton> upgradeButtons;

    [SerializeField] GameObject HealthBar;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenPanel(List<UpgradeData> upgraDatas)
    {
        Clean();
        pauseManager.PauseGame();
        pauseManager.panelOpened = true;
        panel.SetActive(true);
        HealthBar.SetActive(false);

        for (int i = 0; i < upgraDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgraDatas[i]);
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        GameOverScreen.Upgrade(pressedButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
        HideButtons();
        pauseManager.panelOpened = false;
        pauseManager.UnPauseGame();
        panel.SetActive(false);
        HealthBar.SetActive(true);

    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

}
