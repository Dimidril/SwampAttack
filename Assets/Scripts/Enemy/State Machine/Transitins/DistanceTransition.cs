﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitinRange;
    [SerializeField] private float _rangetSpread;

    private void Start()
    {
        _transitinRange += Random.Range(-_rangetSpread, _rangetSpread);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitinRange)
        {
            NeedTransit = true;
        }
    }
}