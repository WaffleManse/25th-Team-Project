using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;

    protected virtual void awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping_single") == false)
            {
                animator.SetBool("Jumping_single", true);
            }
        }

    }
}
