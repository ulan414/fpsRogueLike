using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] UpgradePanelManager upgradePanelManager;
    public Text pointsText;
    public int points = 0;
    public int level = 0;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

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
        if(points == 2)
        {
            if(selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(GetUpgrades(4));

            upgradePanelManager.OpenPanel(selectedUpgrades);
            points = 0;
            level++;
        }
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for(int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if(acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }
}
