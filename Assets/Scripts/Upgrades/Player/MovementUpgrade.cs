using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Player/Movement Speed")]
public class MovementUpgrade : UpgradeData
{
    public float movementIncrease;

    public override void ApplyUpgrade(GameObject player, int level)
    {
        player.GetComponent<PlayerMovement>().bonusMovementSpeed = movementIncrease * level;
    }
}
