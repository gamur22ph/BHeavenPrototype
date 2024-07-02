using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private List<Attack> attacks;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform.Find("Attacks"))
        {
            attacks.Add(child.GetComponent<Attack>());
        }
    }

    // Update is called once per frame
    public void HandleAttack()
    {
        foreach(Attack attack in attacks)
        {
            if (attack.cooldownTimer.timeLeft <= 0 && attack.HasEnemyInRange())
            {
                attack.Activate();
            }
            if (attack.IsActivated()) // If the attack is activated, call attack's attack process
            {
                attack.AttackProcess();
            }
        }
    }

    public GameObject FindAttack(string attackName)
    {
        foreach(Attack attack in attacks)
        {
            if (attack.attackData.attackName == attackName)
            {
                return attack.gameObject;
            }
        }
        return null;
    }

    public void AddAttack(GameObject attack)
    {
        GameObject newAttack = Instantiate(attack, transform.Find("Attacks"));
        newAttack.transform.localPosition = Vector3.zero;
        print(newAttack.name);
        attacks.Add(newAttack.GetComponent<Attack>());
    }

    public bool HasProcessingAttack()
    {
        foreach(Attack attack in attacks)
        {
            if (attack.IsActivated())
            {
                return true;
            }
        }
        return false;
    }

    public bool IsReadyToAttack()
    {
        foreach (Attack attack in attacks)
        {
            if (attack.cooldownTimer.timeLeft <= 0)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsEnemyInRange() 
    {
        foreach(Attack attack in attacks)
        {
            if (attack.HasEnemyInRange())
            {
                return true;
            }
        }
        return false;
    }
}
