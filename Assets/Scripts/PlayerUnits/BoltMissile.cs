﻿using UnityEngine;

public class BoltMissile : MonoBehaviour
{
    public BallistaController ballista;

    private Transform target;

    private GameObject enemy;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(ballista.turret.enemyTag);

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = ballista.turret.stats.missileSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject bloodSpatter = (GameObject)Instantiate(ballista.turret.stats.impactEffect, transform.position, transform.rotation);
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
            e.TakeDamage(ballista.turret.stats.damage);
        }
    }
}
