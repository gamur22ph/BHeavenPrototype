using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        MOVING,
        ATTACKING,
        HURT,
    }

    public SpriteRenderer sprite;
    public GameObject XPDrop;
    [HideInInspector]
    public AnimationController animController;
    [SerializeField] private float baseMovementSpeed;
    private float currentMovementSpeed;
    private STATE state = STATE.IDLE;
    private Health health;
    [HideInInspector]
    public EnemyMovement movement;
    private AttackHandler attackHandler;
    private AudioSource hurtSound;

    private float colorGB = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        movement = GetComponent<EnemyMovement>();
        animController = sprite.GetComponent<AnimationController>();
        attackHandler = GetComponent<AttackHandler>();
        hurtSound = transform.Find("Hurt").GetComponent<AudioSource>();
        currentMovementSpeed = baseMovementSpeed;
        health.OnHealthDepleted += HandleDeath;
        health.OnDamageTaken += HandleDamageTaken;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.HURT:
                
                if (colorGB >= 1)
                {
                    state = STATE.IDLE;
                }
                break;
        }
        colorGB += Time.deltaTime * 3;
        sprite.color = new Color(1, colorGB, colorGB);
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case STATE.IDLE:
                state = STATE.MOVING;
                animController.ChangeAnimationTo("moving");
                if (attackHandler.IsEnemyInRange() && attackHandler.IsReadyToAttack()) state = STATE.ATTACKING;
                break;
            case STATE.MOVING:
                movement.HandleMovement(currentMovementSpeed);
                animController.ChangeAnimationTo("moving");
                HandleFlip();
                if (attackHandler.IsEnemyInRange() && attackHandler.IsReadyToAttack()) state = STATE.ATTACKING;
                break;
            case STATE.ATTACKING:
                attackHandler.HandleAttack();
                if (!attackHandler.HasProcessingAttack())
                {
                    state = STATE.IDLE;
                }
                break;
            default:
                break;
        }
    }

    public void HandleFlip()
    {
        if (movement.GetDirection().x < 0){
            sprite.flipX = true;
        }
        else if(movement.GetDirection().x > 0)
        {
            sprite.flipX = false;
        }
    }

    public void HandleDamageTaken()
    {
        colorGB = 0;
        sprite.color = new Color(1, colorGB, colorGB);
        hurtSound.Play();
        if (state != STATE.ATTACKING)
        {
            animController.ForcePlayAnimation("hurt");
            movement.StopMovement();
            state = STATE.HURT;
        }
    }

    public void HandleDeath()
    {
        Instantiate(XPDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
