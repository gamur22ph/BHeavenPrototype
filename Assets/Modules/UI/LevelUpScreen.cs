using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScreen : MonoBehaviour
{
    public delegate void OnUpgradeConcludedDelegate();
    public event OnUpgradeConcludedDelegate OnUpgradeConcluded;

    public List<UpgradeData> possibleUpgrades;
    public UpgradeCard[] upgradeCards = new UpgradeCard[3];
    UpgradeManager userUpgrades;

    private void Awake()
    {
        userUpgrades = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeManager>();
        print(userUpgrades);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(UpgradeCard upgradeCard in upgradeCards)
        {
            upgradeCard.OnChosen += HandleChosenUpgrade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleUpgrades()
    {
        List<int> upgradeIndices = new List<int>();
        for(int i = 0; i < possibleUpgrades.Count; i++)
        {
            upgradeIndices.Add(i);
        }

        foreach(UpgradeCard upgradeCard in upgradeCards)
        {
            int upgradeIndex = Random.Range(0, upgradeIndices.Count);
            upgradeCard.upgradeData = possibleUpgrades[upgradeIndices[upgradeIndex]];
            print(userUpgrades);
            print(upgradeCard.upgradeData.upgradeName);
            if (userUpgrades.HasCard(upgradeCard.upgradeData))
            {
                upgradeCard.currentLevel = userUpgrades.GetUpgradeCard(upgradeCard.upgradeData).currentLevel;
            }
            upgradeCard.UpgradeSetup();

            upgradeIndices.RemoveAt(upgradeIndex);
        }
    }

    public void HandleChosenUpgrade(UpgradeCard upgradeCard)
    {
        if (userUpgrades.HasCard(upgradeCard.upgradeData))
        {
            userUpgrades.UpgradeExistingCard(upgradeCard);
        }
        else
        {
            userUpgrades.AddUpgradeCard(upgradeCard);
        }
        CloseUpgrade();
    }

    public void OpenUpgrade()
    {
        
        gameObject.SetActive(true);
        ShuffleUpgrades();
        Time.timeScale = 0;
    }

    public void CloseUpgrade()
    {
        OnUpgradeConcluded?.Invoke();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
