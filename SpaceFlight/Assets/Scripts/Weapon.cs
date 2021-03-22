using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject prefab;
    public Transform shootPoint;
    Rigidbody prefabRig;
    Rigidbody aircraftRig;

    float delay = .1f;
    float timeToShoot;
    public bool isShooting { get; private set; }
    
    void Awake()
    {
        prefabRig = prefab.GetComponent<Rigidbody>();
        aircraftRig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (CanShoot() && !GameState._gameEnded)
            OnShoot();
    }

    void OnShoot()
    {
        timeToShoot = Time.time + delay;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            isShooting = true;

            prefabRig.velocity += aircraftRig.velocity;
            Vector3 shootPosition = shootPoint.position;

            Instantiate(prefab, shootPosition, transform.rotation);
        }
        else
            isShooting = false;
    }

    bool CanShoot()
    {
        return Time.time >= timeToShoot;
    }
}
