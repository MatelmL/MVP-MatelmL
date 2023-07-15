using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAttack(bool value)
    {
        animator.SetBool("Attack", value);
    }
    public void SetSpeed(float value)
    {
        animator.SetFloat("Speed", value);
    }
}
