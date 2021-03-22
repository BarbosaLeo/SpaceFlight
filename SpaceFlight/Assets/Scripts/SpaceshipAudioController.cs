using UnityEngine;

public class SpaceshipAudioController : MonoBehaviour
{
    AudioSource engineSound;
    PlayerAircraftMovement aircraft;
    Rigidbody aircraftRig;

    private void Awake()
    {
        aircraft = GetComponent<PlayerAircraftMovement>();
        aircraftRig = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        float cPitch = aircraftRig.velocity.magnitude / 10f;

        engineSound.pitch = cPitch;
        engineSound.volume = aircraft.throttle/2f;
    }
}
