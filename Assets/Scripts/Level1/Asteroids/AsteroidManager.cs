using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroidTemplate;
    public List<Asteroid> oribitingAsteroids = new List<Asteroid>();
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public float minSpeed = 800f / ApplicationModel.Planet1Radius;
    public float maxSpeed = 800f / ApplicationModel.Planet1Radius;
    public float maxLocalRotation = 3f;
    public bool freeze = false;

    private readonly Random _rand = new Random();

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnAsteroidAt(_rand.Next(0, 359), _rand.Next(0, 359));
        }

        // UpdateInner all the asteroids
        for (int i = oribitingAsteroids.Count - 1; i >= 0; i--)
        {
            var asteroid = oribitingAsteroids[i];
            if (!freeze)
                asteroid.UpdateInner();
            
            if (!asteroid.IsAlive())
                oribitingAsteroids.RemoveAt(i);
        }
    }

    /// <summary>
    /// Creates a new asteroid
    /// </summary>
    /// <param name="xAngle">X axis</param>
    /// <param name="yAngle">Y axis</param>
    public void SpawnAsteroidAt(int xAngle, int yAngle)
    {
        var clone = Instantiate(asteroidTemplate);

        // set scale
        var scale = (float)_rand.NextDouble() * maxScale + minScale;
        clone.transform.localScale = new Vector3(scale, scale, scale);

        // set random spawn location
        clone.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0f);

        // set random direction to move -> Vector2([-1;1],[-1;1]) (TODO: I am not sure if this works correctly...)
        asteroidTemplate.transform.LookAt(Vector3.zero, new Vector3((float)_rand.NextDouble() * 2 - 1, (float)_rand.NextDouble() * 2 - 1).normalized);

        var asteroid = new Asteroid(
            gameObject: clone,
            movementSpeed: (float) _rand.NextDouble()*maxSpeed + minSpeed,
            localRotation: new Vector3(
                x: (float) _rand.NextDouble()*maxLocalRotation,
                y: (float) _rand.NextDouble()*maxLocalRotation,
                z: (float) _rand.NextDouble()*maxLocalRotation));
        //asteroid._isDescending = false;
        oribitingAsteroids.Add(asteroid);
    }
}
