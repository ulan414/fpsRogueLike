using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string ScriptName;
    public string Name;
    public string Description;
    public Sprite icon;
    public int AddDamage;
    public int AddFireDelay;
    public int AddVampHealth;
    public int AddMaxHealth;
}
