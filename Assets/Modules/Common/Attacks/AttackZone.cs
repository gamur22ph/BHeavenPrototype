using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float damage;
    private List<GameObject> targets = new List<GameObject>();
    public LayerMask attackLayer;
    public Timer attackTimer;
    public SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Mathf.Log(attackLayer.value, 2))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == Mathf.Log(attackLayer.value, 2))
        {
            targets.Remove(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer.timeLeft == 0)
        {
            AttackAllTargets();
            gameObject.SetActive(false);
        }
        else
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Clamp(((attackTimer.waitTime - attackTimer.timeLeft)/attackTimer.waitTime), 0, 0.75f));
        }
    }

    public void AttackAllTargets()
    {
        foreach(GameObject attackTarget in targets)
        {
            attackTarget.GetComponent<IDamageable>().Damage(damage);
        }
    }
}
