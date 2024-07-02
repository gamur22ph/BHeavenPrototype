using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Player/Health")]
public class HealthUpgrade : UpgradeData
{
    public float healthIncrease;

    public override void ApplyUpgrade(GameObject player, int level)
    {
        throw new System.NotImplementedException();
    }
}
