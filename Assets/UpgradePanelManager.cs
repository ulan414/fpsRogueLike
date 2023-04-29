using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    [SerializeField] List<UpgradeButton> upgradeButtons;

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
        panel.SetActive(true);
        pauseManager.panelOpened = true;

        for(int i = 0; i < upgraDatas.Count; i++)
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
        Debug.Log("close panel");
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
