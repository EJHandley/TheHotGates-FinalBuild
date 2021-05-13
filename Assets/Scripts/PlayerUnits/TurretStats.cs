using UnityEngine;

[System.Serializable]
public class TurretStats
{
    [Header("For All Units")]
    public GameObject prefab;
    public GameObject preview;
    public string buildSound;
    public int purchaseValue;
    public int sellValue;

    public float startHealth;
    public float health;

    public int startDamage;
    public int damage;

    public GameObject impactEffect;

    [Header("For All Attacking Units")]
    public float attackRange;
    public float attackSpeed;
    public float attackReset;

    [Header("For Turrets")]
    public GameObject missilePrefab;
    public float missileSpeed;
    public Transform firePoint;
    public Transform rotationPoint;
    public float turnSpeed;

    [Header("For Catapults and Stone Wall")]
    public float explosionRadius;

    [Header("For Ditch")]
    public float slowStrength;
    public float slowRadius;
}
