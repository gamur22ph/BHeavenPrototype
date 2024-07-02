using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [HideInInspector]
    public string currentAnimation;
    [HideInInspector]
    public Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationTo(string newAnimation)
    {
        if (currentAnimation != newAnimation)
        {
            animator.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }
    public void ForcePlayAnimation(string newAnimation)
    {
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    public void SetAnimator(Animator newAnimator)
    {
        animator = newAnimator;
    }
}
