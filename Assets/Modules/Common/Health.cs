using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public delegate void OnHealthChangedDelegate(float amount);
    public delegate void OnDamageTakenDelegate();
    public delegate void OnHealthDepletedDelegate();
    public event OnHealthChangedDelegate OnHealthChanged;
    public event OnDamageTakenDelegate OnDamageTaken;
    public event OnHealthDepletedDelegate OnHealthDepleted;

    [SerializeField] float baseHealth;
    [HideInInspector]
    public float maxHealth;
    float currentHealth { get; set; }
    private GameObject damagePopupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        damagePopupPrefab = Resources.Load<GameObject>("UI/DamagePopup");
        maxHealth = baseHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            OnHealthDepleted?.Invoke();
        }
    }

    public void Damage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        SpawnDamagePopUp(amount);
        UpdateHealth();
        OnDamageTaken?.Invoke();
    } 

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void UpdateHealth()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void SpawnDamagePopUp(float damageNumber)
    {
        GameObject newDamagePopUp = Instantiate(damagePopupPrefab);
        newDamagePopUp.transform.localPosition = transform.position + (Vector3.up * 0.5f);
        newDamagePopUp.GetComponent<FadePopup>().ChangeText(damageNumber);
    }
}
