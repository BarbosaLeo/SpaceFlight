using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{   
    public Spawner spawner;
    private GameObject closestEnemy;
    public GameObject trackerPointer;

    void Update()
    {
        

        float minDistance = Mathf.Infinity;
        if(closestEnemy != null)
        {

        }

        closestEnemy = null;

        foreach(GameObject enemy in spawner.enemiesLocation)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (spawner.enemiesLocation.Count > 0)
        {
            Vector3 targetHeading = closestEnemy.transform.position - transform.position;
            float targetDistance = targetHeading.magnitude;
            Vector3 direction = targetHeading / targetDistance;

            trackerPointer.transform.forward = direction;

            Debug.DrawLine(transform.position, closestEnemy.transform.position, Color.red);
        }

        if(spawner.enemiesLocation.Count == 0)
        {
            GameState._gameEnded = true;
        }
    }
}
