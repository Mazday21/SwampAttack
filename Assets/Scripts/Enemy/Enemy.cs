using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    private Player _target;
    private Animator _animator;

    public event UnityAction<Enemy> Dying;
    public Player Target => _target;
    public int Reward => _reward;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            State attack = GetComponent<AttackState>();
            State move = GetComponent<MoveState>();
            attack.enabled = false;
            move.enabled = false;
            _animator.SetBool("die", true);
            Destroy(gameObject, 1);
        }
    }
}
