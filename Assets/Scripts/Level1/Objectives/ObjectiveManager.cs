using System.Collections.Generic;
using System.Linq;

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

    protected override void Awake()
    {
        base.Awake();

        _objectives.Clear();
        
        var objective1 = new DestroyAsteroidsObjective(1);
        _objectives.Add(objective1);
        _currentObjective = _objectives[_pointer];
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
                LevelManager.Win();
            }

            _currentObjective = _objectives.GetNextElement(ref _pointer);
        }
    }

    private bool AreAllObjectivesEnded()
    {
        return _objectives.All(x => x.IsDead);
    }
}
