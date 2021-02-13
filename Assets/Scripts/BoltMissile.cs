﻿using UnityEngine;

public class BoltMissile : MonoBehaviour
{
    private Transform target;

    public float speed = 100f;

    public GameObject impactEffect;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
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
        return;
    }
}