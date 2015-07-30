/// <summary>
/// Task to destroy x asteroids.
/// </summary>
public class DestroyAsteroidsObjective : Objective
{
    private readonly int _asteroidsToDestroy;
    private int _asteroidsDestroyed;

    public DestroyAsteroidsObjective(int howMany)
    {
        _asteroidsToDestroy = howMany;
    }

    public override void OnStart()
    {
        base.OnStart();
        AsteroidManager.Instance.OnAsteroidDestroy += IncrementAndCheck;    
    }

    public override void OnEnd()
    {
        base.OnEnd();
        AsteroidManager.Instance.OnAsteroidDestroy -= IncrementAndCheck;
    }

    private void IncrementAndCheck(object sender)
    {
        if (++_asteroidsDestroyed >= _asteroidsToDestroy)
            State = ObjectiveState.Completed;
    }
}
