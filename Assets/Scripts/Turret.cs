using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float reloadTime = 1f;


    [Header("Unity Setup Fields")]       
    public string enemyTag = "Enemy";
    public Transform top;
    public float turnSpeed = 10f;

    public GameObject boltPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
       
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        // Ballista Aiming
        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(top.rotation, aimRotation, Time.deltaTime * turnSpeed).eulerAngles;
        top.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(reloadTime <= 0f)
        {
            Shoot();
            reloadTime = 1f / fireRate;
        }

        reloadTime -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject boltFired = Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
        BoltMissile bolt = boltFired.GetComponent<BoltMissile>();

        if(bolt != null)
        {
            bolt.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}
