using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public delegate void OnXPChangedDelegate();
    public event OnXPChangedDelegate OnXPChanged;
    public UnityEvent OnLevelUp;

    public int currentLevel = 1;
    public int maxXP;
    public int currentXP;

    public float basePickUpRange = 1;
    private float currentPickUpRange;
    private GameObject pickUpZone;

    // Start is called before the first frame update
    void Start()
    {
        pickUpZone = transform.Find("PickUpZone").gameObject;
        currentPickUpRange = basePickUpRange;
        pickUpZone.GetComponent<CircleCollider2D>().radius = currentPickUpRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainXP(int amount)
    {
        currentXP += amount;
        while (currentXP >= maxXP)
        {
            currentLevel += 1;
            currentXP -= maxXP;
            OnLevelUp?.Invoke();
        }
        OnXPChanged?.Invoke();
    }
}
