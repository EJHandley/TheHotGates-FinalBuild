﻿using UnityEngine;

public class BoltMissile : MonoBehaviour
{
    private Transform target;

    public float speed = 100f;
    public int damage = 50;

    public GameObject impactEffect;
    public GameObject enemy;

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

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject bloodSpatter = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(bloodSpatter, 2f);

        Destroy(gameObject);
        Damage(target.transform);

        return;
    }

    void Damage(Transform enemy)
    {
        EnemyHealth e = enemy.GetComponent<EnemyHealth>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}