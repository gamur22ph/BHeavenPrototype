using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class UpgradeData : ScriptableObject
{

    [Header("Upgrade")]
    public int maxLevel;
    public string upgradeName;
    [TextArea] public string upgradeDescription;

    public abstract void ApplyUpgrade(GameObject player, int level);
}
