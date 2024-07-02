using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image healthBar;
    public Image xpBar;
    public TextMeshProUGUI levelText;

    public GameObject levelupScreen;
    private int levelUpCount;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().OnHealthChanged += UpdateHealthBar;
        player.GetComponent<Stats>().OnXPChanged += UpdateXPBar;
        levelupScreen.GetComponent<LevelUpScreen>().OnUpgradeConcluded += HandleUpgradeConclusion;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelUpCount > 0 && !levelupScreen.activeInHierarchy)
        {
            levelupScreen.GetComponent<LevelUpScreen>().OpenUpgrade();
        }
    }

    public void UpdateHealthBar(float amount)
    {
        healthBar.fillAmount = amount / player.GetComponent<Health>().maxHealth;
    }

    public void UpdateXPBar()
    {
        xpBar.fillAmount = (float)player.GetComponent<Stats>().currentXP / (float)player.GetComponent<Stats>().maxXP;
    }

    public void UpdateLevel()
    {
        levelText.text = player.GetComponent<Stats>().currentLevel.ToString();
        levelUpCount += 1;
    }

    public void HandleUpgradeConclusion()
    {
        levelUpCount -= 1;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
