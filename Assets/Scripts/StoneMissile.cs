using UnityEngine;

public class StoneMissile : MonoBehaviour
{
    private Transform target;

    public float speed = 100f;

    public GameObject impactEffect;
    public GameObject enemy;

    public float explosionRadius = 0f;

    public string enemyTag = "Enemy";

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(enemyTag);

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

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
        GameObject bloodSpatter = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(bloodSpatter, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);

        return;
    }

    void Explode ()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
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
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
