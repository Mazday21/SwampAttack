using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    [SerializeField] private float _timeBeforeDestroy;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Die");
        Destroy(gameObject,_timeBeforeDestroy);
    }
}
