using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour 
{
    private readonly List<Bullet> _bullets = new List<Bullet>(); 

    void Update()
    {
        for (int i = _bullets.Count - 1; i >= 0; i--)
        {
            var bullet = _bullets[i];
            if (!bullet.IsAlive())
            {
                _bullets.RemoveAt(i);
                continue;
            }

            bullet.Update();
        }
    }

    public void Add(Bullet bullet)
    {
        _bullets.Add(bullet);
    }
}
