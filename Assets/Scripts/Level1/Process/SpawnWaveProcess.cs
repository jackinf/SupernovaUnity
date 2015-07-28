using Random = System.Random;

public class SpawnWaveProcess : Process 
{
    private readonly AsteroidManager _asteroidManager;
    private readonly int _asteroids;
    private readonly Random _rand = new Random();

    public SpawnWaveProcess(AsteroidManager asteroidManager, int asteroids)
    {
        _asteroidManager = asteroidManager;
        _asteroids = asteroids;
    }

    public override void OnUpdate(float fixedDeltaTime)
    {
        base.OnUpdate(fixedDeltaTime);

        for (int i = 0; i < _asteroids; i++)
        {
            _asteroidManager.SpawnAsteroidAt(_rand.Next(0, 359), _rand.Next(0, 359));
        }

        State = ProcessState.Succeeded;
    }

}
