using UnityEngine;

public class DitchController: MonoBehaviour
{
    EnemyController enemy;

    public TurretStats stats;

    [Header("Ditch Slow Attributes")]
    public float slowStrength = 0.5f;
    public float slowRadius = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        float enemyInDitch = Vector3.Distance(enemy.transform.position, transform.position);
        if(enemyInDitch <= slowRadius)
        {
            SlowEnemy();
        }
    }

    void SlowEnemy()
    {
        enemy.Slow(slowStrength);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, slowRadius);
    }
}
