using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour 
{
    private List<Bullet> bullets = new List<Bullet>(); 

    void Update()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            var bullet = bullets[i];
            if (!bullet.IsAlive())
            {
                bullets.RemoveAt(i);
                continue;
            }

            bullet.OuterUpdate();
        }
    }

    public void Add(Bullet bullet)
    {
        bullets.Add(bullet);
    }
}
