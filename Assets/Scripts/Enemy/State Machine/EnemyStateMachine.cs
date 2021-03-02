using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _curentState;

    public State Curent => _curentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_curentState == null)
            return;

        var nextState = _curentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _curentState = startState;

        if (_curentState != null)
            _curentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_curentState != null)
            _curentState.Exit();

        _curentState = nextState;

        if (_curentState != null)
            _curentState.Enter(_target);
    }
}