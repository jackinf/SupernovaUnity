﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manages objectives for a player.
/// What tasks must player do in order to win the level?
/// </summary>
public class ObjectiveManager : Singleton<ObjectiveManager>
{
    protected ObjectiveManager() { }

    private readonly List<Objective> _objectives = new List<Objective>();
    private int _pointer;
    private Objective _currentObjective;
    private GameObject _player;

    protected override void Awake()
    {
        base.Awake();

        _objectives.Clear();
        
        var objective1 = new DestroyAsteroidsObjective(100);
        _objectives.Add(objective1);
        _currentObjective = _objectives[_pointer];

        _player = GameObject.FindGameObjectWithTag("Player");       // TODO: Singleton pattern?
    }

    void FixedUpdate()
    {
        if (_currentObjective == null)
            return;

        if (_currentObjective.State == ObjectiveState.NotStarted)
            _currentObjective.OnStart();

        if (_currentObjective.State == ObjectiveState.InProgress)
            _currentObjective.OnUpdate();

        if (_currentObjective.IsDead)
        {
            if (AreAllObjectivesEnded())
            {
                try
                {
                    _player.GetComponent<PlayerController>().SetInvincible(true);
                    StartCoroutine(DelayedWin());
                }
                catch
                {
                    // We failed to make player invincible. Fallback action: change scenes immedeately!
                    Debug.Log("Failed to disable a player");
                    LevelManager.Win();
                }
            }

            _currentObjective = _objectives.GetNextElement(ref _pointer);
        }
    }

    IEnumerator DelayedWin()
    {
        yield return new WaitForSeconds(2f);
        LevelManager.Win();
    }

    private bool AreAllObjectivesEnded()
    {
        return _objectives.All(x => x.IsDead);
    }
}
