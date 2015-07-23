using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroidTemplate;
    public List<Asteroid> oribitingAsteroids = new List<Asteroid>();

    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    public float minSpeed = 50f;
    public float maxSpeed = 50f;

    public float maxLocalRotation = 3f;

    private GameObject player;
    private Random rand = new Random();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Create an asteroid with a key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var fromPosition = player.transform.position * -1;
            var randomMoveDirection = new Vector3((float) rand.NextDouble() * 2 - 1, (float) rand.NextDouble() * 2 - 1).normalized;

            asteroidTemplate.transform.LookAt(fromPosition, fromPosition + randomMoveDirection);        // set direction to move to
            var scale = (float) rand.NextDouble()*maxScale + minScale;
            asteroidTemplate.transform.localScale = new Vector3(scale, scale, scale);    // set scale

            var asteroid = new Asteroid(
                gameObject: Instantiate(asteroidTemplate),
                movementSpeed: (float) rand.NextDouble()* maxSpeed + minSpeed,
                localRotation: new Vector3(
                    x: (float) rand.NextDouble() * maxLocalRotation, 
                    y: (float) rand.NextDouble() * maxLocalRotation, 
                    z: (float) rand.NextDouble() * maxLocalRotation));

            oribitingAsteroids.Add(asteroid);
        }

        // Update all the asteroids
        for (int i = oribitingAsteroids.Count - 1; i >= 0; i--)
        {
            var asteroid = oribitingAsteroids[i];
            asteroid.Update();

            if (!asteroid.IsAlive())
                oribitingAsteroids.RemoveAt(i);
        }
    }
}
