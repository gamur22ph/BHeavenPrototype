using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    public delegate void OnChosenDelegate(UpgradeCard upgradeCard);
    public event OnChosenDelegate OnChosen;
    
    public int currentLevel = 0;

    public UpgradeData upgradeData;
    public TextMeshProUGUI upgradeTitle;
    public TextMeshProUGUI levelUI;
    public TextMeshProUGUI descriptionUI;
    [HideInInspector] public Button upgradeButton;

    private void Awake()
    {
        upgradeButton = GetComponent<Button>();
    }

    public void UpgradeSetup()
    {
        upgradeTitle.text = upgradeData.upgradeName;
        if (upgradeData.maxLevel == 0)
        {
            levelUI.text = "";
        }
        else
        {
            levelUI.text = (currentLevel + 1).ToString();
        }
        descriptionUI.text = upgradeData.upgradeDescription;
    }

    public void PlayerSetup()
    {
        upgradeTitle.text = upgradeData.upgradeName;
        if (upgradeData.maxLevel == 0)
        {
            levelUI.text = "";
        }
        else
        {
            levelUI.text = currentLevel.ToString();
        }
        descriptionUI.text = upgradeData.upgradeDescription;
    }

    public void SelectUpgrade()
    {
        OnChosen?.Invoke(this);
    }

    public int LevelUp(int levelAmount = 1)
    {
        currentLevel += levelAmount;
        return currentLevel;
    }

    public void EnableUpgrade()
    {
        upgradeButton.enabled = true;
    }

    public void DisableUpgrade()
    {
        upgradeButton.enabled = false;
    }
}
