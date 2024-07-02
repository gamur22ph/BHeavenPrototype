using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Attack/Simple Sword/Slash Rate")]
public class IncreaseSlashRate : AttackUpgradeData
{
    public float rateIncrease;

    public override void ApplyUpgrade(GameObject player, int level)
    {
        GameObject attackToUpgrade = player.GetComponent<AttackHandler>().FindAttack(attackData.attackName);
        attackToUpgrade.GetComponent<SimpleSword>().ApplyBonusAttackRate(rateIncrease * level);
    }
}
    