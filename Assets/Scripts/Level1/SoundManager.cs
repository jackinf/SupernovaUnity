using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _asteroidHitSound;
    private AudioSource _explosionSound;
    private AudioSource _deathSound;
    private AudioSource _pickupSound;
    private AudioSource _shootingSound;

    protected override void Awake()
    {
        base.Awake();

        _asteroidHitSound = transform.FindChild("AsteroidHit").GetComponent<AudioSource>();
        _explosionSound = transform.FindChild("Explosion").GetComponent<AudioSource>();
        _deathSound = transform.FindChild("Death").GetComponent<AudioSource>();
        _pickupSound = transform.FindChild("Pickup").GetComponent<AudioSource>();
        _shootingSound = transform.FindChild("Shooting").GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        _asteroidHitSound.Play();
    }

    public void PlayExplosionSound()
    {
        _explosionSound.Play();
    }

    public void PlayDeathSound()
    {
        _deathSound.Play();
    }

    public void PlayPickupSound()
    {
        _pickupSound.Play();
    }

    public void PlayShootingSound()
    {
        _shootingSound.Play();
    }
}
