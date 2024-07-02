using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Attack/New")]
public class AttackAcquisitionUpgrade : UpgradeData
{
    public GameObject AcquiredWeapon;

    public override void ApplyUpgrade(GameObject player, int level)
    {
        player.GetComponent<AttackHandler>().AddAttack(AcquiredWeapon);
    }
}
