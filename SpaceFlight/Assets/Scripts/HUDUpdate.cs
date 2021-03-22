using TMPro;
using UnityEngine;

public class HUDUpdate : MonoBehaviour
{
    public GameObject aircraft;
    Rigidbody aircraftRig;
    PlayerAircraftMovement aircraftMovement;
    public TMP_Text speed;
    public TMP_Text throttle;

    static int _points;
    static int _enemies;

    static HUDUpdate _instance;

    void Awake() => _instance = this;

    [SerializeField] TMP_Text points;
    [SerializeField] TMP_Text enemies;

    private void Start()
    {
        aircraftMovement = aircraft.GetComponent<PlayerAircraftMovement>();
        aircraftRig = aircraft.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        AircraftStats();
    }

    void AircraftStats()
    {
        if (aircraftRig != null)
        {
            speed.SetText("Velocidade: " + aircraftRig.velocity.magnitude.ToString("00"));
        }
        if(aircraftRig != null)
        {
            throttle.SetText("Throttle: " + aircraftMovement.throttle.ToString("0.0"));
        }

    }

    public static void AddPoints(int increment)
    {
        _points += increment;
        _instance.points.SetText("Pontos: " + _points.ToString("0000"));
    }

    public static void EnemiesCounter(int totalEnemies)
    {
        _enemies = totalEnemies;
        _instance.enemies.SetText("Inimigos: " + _enemies.ToString("00"));
    }
}
