using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Attack/Simple Sword/Slash Damage")]
public class IncreaseSlashDamage : AttackUpgradeData
{
    public float damageIncrease;

    public override void ApplyUpgrade(GameObject player, int level)
    {
        GameObject attackToUpgrade = player.GetComponent<AttackHandler>().FindAttack(attackData.attackName);
        attackToUpgrade.GetComponent<SimpleSword>().ApplyBonusDamage(damageIncrease * level);



    }
}
