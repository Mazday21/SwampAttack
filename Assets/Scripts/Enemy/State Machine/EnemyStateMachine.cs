using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{

    [SerializeField] private State _startState;
    
    private Player _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
    }

    private void Update()
    {
        if(_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
            {
                _currentState.Enter(_target);
            }
        }
    }

    private void Reset(State start)
    {
        _currentState = start;
        if(_currentState != null)
            _currentState.Enter(_target);
    }
}
