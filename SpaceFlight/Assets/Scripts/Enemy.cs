using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Spawner spawner;
    public GameObject particle;

    [SerializeField] int healthAmount = 10;
    [SerializeField]int pointsAmount = 100;

    void Awake()
    {
        spawner = GetComponentInParent<Spawner>();
    }

    void Update()
    {
        if(healthAmount <= 0)
        {
            spawner.EnemyCounter();
            HUDUpdate.AddPoints(pointsAmount);
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var bullet = collision.collider.GetComponent<Bullet>();

        if(bullet != null)
        {
            healthAmount -= bullet.bulletDamage;

            if(healthAmount == 0)
            {
                spawner.enemiesLocation.Remove(this.gameObject);
            }
        }
    }
}
