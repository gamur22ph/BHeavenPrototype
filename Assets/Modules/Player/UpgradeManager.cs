using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<GameObject> upgradeCards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddUpgradeCard(UpgradeCard newUpgradeCard)
    {
        GameObject upgradeCardDuplicate = Instantiate(newUpgradeCard.gameObject);
        upgradeCardDuplicate.GetComponent<UpgradeCard>().currentLevel += 1;
        upgradeCards.Add(upgradeCardDuplicate);
        upgradeCardDuplicate.GetComponent<UpgradeCard>().upgradeData.ApplyUpgrade(gameObject, upgradeCardDuplicate.GetComponent<UpgradeCard>().currentLevel);
    }

    public void UpgradeExistingCard(UpgradeCard upgradeThisCard)
    {
        for(int i = 0; i < upgradeCards.Count; i++)
        {
            if(upgradeCards[i].GetComponent<UpgradeCard>().upgradeData.upgradeName == upgradeThisCard.upgradeData.upgradeName)
            {
                upgradeCards[i].GetComponent<UpgradeCard>().LevelUp();
                upgradeCards[i].GetComponent<UpgradeCard>().upgradeData.ApplyUpgrade(gameObject, upgradeCards[i].GetComponent<UpgradeCard>().currentLevel);
            }
        }
    }

    public bool HasCard(UpgradeData upgradeInformation)
    {
        for(int i = 0; i < upgradeCards.Count; i++)
        {
            if(upgradeCards[i].GetComponent<UpgradeCard>().upgradeData.upgradeName == upgradeInformation.upgradeName)
            {
                return true;
            }
        }
        return false;
    }

    public UpgradeCard GetUpgradeCard(UpgradeData upgradeInformation)
    {
        for (int i = 0; i < upgradeCards.Count; i++)
        {
            if (upgradeCards[i].GetComponent<UpgradeCard>().upgradeData.upgradeName == upgradeInformation.upgradeName)
            {
                return upgradeCards[i].GetComponent<UpgradeCard>();
            }
        }
        return null;
    }
}
