using System.Collections.Generic;

/// <summary>
/// Updates all the bullets in the game.
/// TODO: Add pool of bullets in order to reuse them for better efficiency. 
/// </summary>
public class BulletManager : Singleton<BulletManager>
{
    protected BulletManager() { }

    private readonly List<Bullet> _bullets = new List<Bullet>(); 

    void FixedUpdate()
    {
        for (int i = _bullets.Count - 1; i >= 0; i--)
        {
            var bullet = _bullets[i];
            if (!bullet.IsAlive())
            {
                _bullets.RemoveAt(i);
                continue;
            }

            bullet.UpdateInner();
        }
    }

    public void Add(Bullet bullet)
    {
        _bullets.Add(bullet);
    }
}
