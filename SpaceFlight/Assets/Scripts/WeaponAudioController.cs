using UnityEngine;

public class WeaponAudioController : MonoBehaviour
{
    public GameObject aircraft;
    Weapon weapon;
    AudioSource gunAudio;

    void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        weapon = aircraft.GetComponent<Weapon>();
    }

    void Update()
    {
        if (weapon.isShooting)
        {
            gunAudio.Play();
        }
        else
            gunAudio.Pause();
    }
}
