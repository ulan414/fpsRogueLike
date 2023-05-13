using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text Name;
    [SerializeField] Text description;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        Name.text = upgradeData.Name;
        description.text = upgradeData.Description;
    }

    public void Clean()
    {
        icon.sprite = null;
        Name.text = " ";
        description.text = " ";
    }
}
