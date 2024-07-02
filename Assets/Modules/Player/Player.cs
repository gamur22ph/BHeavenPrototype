using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    

    [SerializeField] public UnityEvent OnDeath;

    private Health health;
    private PlayerMovement playerMovement;
    private SpriteRenderer sprite;
    private AnimationController animController;
    private AttackHandler attackHandler;

    
    public enum STATE
    {
        IDLE,
        MOVING,
        ATTACKING
    }

    private STATE state = STATE.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        playerMovement = GetComponent<PlayerMovement>();
        sprite = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        animController = sprite.GetComponent<AnimationController>();
        attackHandler = GetComponent<AttackHandler>();
        
        health.OnHealthDepleted += HandleDeath;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                animController.ChangeAnimationTo("idle");
                if (playerMovement.IsMoving())
                {
                    state = STATE.MOVING;
                }
                HandleFlip();
                break;
            case STATE.MOVING:
                animController.ChangeAnimationTo("walk");
                if (!playerMovement.IsMoving())
                {
                    state = STATE.IDLE;
                }
                HandleFlip();
                break;
            case STATE.ATTACKING:
                attackHandler.HandleAttack();
                if (!attackHandler.HasProcessingAttack())
                {
                    if (playerMovement.IsMoving())
                    {
                        state = STATE.MOVING;
                    }
                    else
                    {
                        state = STATE.IDLE;
                    }
                }
                break;
        }
        
    }
    private void FixedUpdate()
    {
        playerMovement.HandleMovement();
        switch (state)
        {
            case STATE.IDLE:
                if (attackHandler.IsEnemyInRange() && attackHandler.IsReadyToAttack()) state = STATE.ATTACKING;
                break;
            case STATE.MOVING:
                if (attackHandler.IsEnemyInRange() && attackHandler.IsReadyToAttack()) state = STATE.ATTACKING;
                break;
        }
    }

    

    void HandleFlip()
    {
        if (playerMovement.GetHorizontalMovement() > 0)
        {
            sprite.flipX = false;
        }
        else if (playerMovement.GetHorizontalMovement() < 0)
        {
            sprite.flipX = true;
        }
    }

    

    void HandleDeath()
    {

        Destroy(gameObject);
        OnDeath?.Invoke();
        Time.timeScale = 0;
    }
}
