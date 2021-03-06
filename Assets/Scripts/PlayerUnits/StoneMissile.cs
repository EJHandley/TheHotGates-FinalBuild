using UnityEngine;

public class StoneMissile : MonoBehaviour
{
    public CatapultController catapultController;

    private Transform target;

    public GameObject enemy;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(catapultController.enemyTag);

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = catapultController.stats.missileSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject bloodSpatter = (GameObject)Instantiate(catapultController.stats.impactEffect, transform.position, transform.rotation);
        Destroy(bloodSpatter, 2f);

        if(catapultController.stats.explosionRadius > 0f)
        {
            Explode();
        }

        return;
    }

    void Explode ()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, catapultController.stats.explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();

        if (e != null)
        {
            e.TakeDamage(catapultController.stats.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, catapultController.stats.explosionRadius);
    }
}
