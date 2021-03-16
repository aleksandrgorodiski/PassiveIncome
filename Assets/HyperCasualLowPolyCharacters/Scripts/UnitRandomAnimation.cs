using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRandomAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(0, 0, Random.Range(0f, 1f));
    }
}
