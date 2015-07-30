using UnityEngine;

/// <summary>
/// Spawns a lot of asteroids at once on random positions.
/// </summary>
public class SpawnWaveProcess : Process 
{
    private readonly int _asteroids;

    public SpawnWaveProcess(int asteroids)
    {
        _asteroids = asteroids;
    }

    public override void OnUpdate(float fixedDeltaTime)
    {
        base.OnUpdate(fixedDeltaTime);

        for (int i = 0; i < _asteroids; i++)
        {
            AsteroidManager.Instance.SpawnAsteroidAt(Random.Range(0, 359), Random.Range(0, 359));
        }

        State = ProcessState.Succeeded;
    }

}
