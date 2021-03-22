using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rigid;
    [SerializeField] int prefabNumber = 150;

    public bool isEnemySpawner;
    int enemiesAlive;

    public List<GameObject> enemiesLocation;

    void Awake()
    {
        rigid = prefab.GetComponent<Rigidbody>();
    }

    void Start()
    {
        if(rigid != null)
        {
            for (int i = 0; i < prefabNumber; i++)
            {
                float x = UnityEngine.Random.Range(-800, 800);
                float y = UnityEngine.Random.Range(-800, 800);
                float z = UnityEngine.Random.Range(-800, 800);

                Vector3 randomLocation = new Vector3(x, y, z);
                Quaternion randomRotation = Quaternion.Euler(x, y, z);

                GameObject enemy = Instantiate(prefab, randomLocation, randomRotation, transform);


                enemiesLocation.Add(enemy);
            }
        }

        if (isEnemySpawner) { enemiesAlive = prefabNumber; }
    }

    void Update()
    {

        if (isEnemySpawner == true)
        {
            HUDUpdate.EnemiesCounter(enemiesAlive);
        }
    }

    public void EnemyCounter()
    {
        enemiesAlive -=1;
    }
}
