using UnityEngine;

public class DitchController: MonoBehaviour
{
    public TurretController barricade;

    [Header("Ditch Slow Attributes")]
    public float slowStrength = 0.5f;
    public float slowRadius = 1f;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemy.Slow(slowStrength);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, slowRadius);
    }
}
