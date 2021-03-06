using UnityEngine;

public class BoltMissile : MonoBehaviour
{
    public BallistaController ballistaController;

    private Transform target;

    public GameObject enemy;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(ballistaController.enemyTag);

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = ballistaController.stats.missileSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject bloodSpatter = (GameObject)Instantiate(ballistaController.stats.impactEffect, transform.position, transform.rotation);
        Destroy(bloodSpatter, 2f);

        Destroy(gameObject);
        Damage(target.transform);

        return;
    }

    void Damage(Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();

        if (e != null)
        {
            e.TakeDamage(ballistaController.stats.damage);
        }
    }
}
