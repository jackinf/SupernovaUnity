/// <summary>
/// To track the state of the player's task, e.g. in order to close it or avoid repeating it.
/// </summary>
public enum ObjectiveState
{
    NotStarted = 0,
    Started = 10,
    InProgress = 20,
    Completed = 30,
    Failed = 40,
    Closed = 50
}

/// <summary>
/// A task which player must do.
/// </summary>
public abstract class Objective
{
    public ObjectiveState State;

    public virtual void OnStart()
    {
        State = ObjectiveState.InProgress;
    }

    public virtual void OnUpdate() { }
    public virtual void OnEnd() { }

    public bool IsDead
    {
        get { return State == ObjectiveState.Completed || State == ObjectiveState.Failed; }
    }
}
