﻿using UnityEngine;

public class DitchController: MonoBehaviour
{
    public TurretController barricade;

    private int isTrue = 1;

    private float moatSlowChange;

    private int pitfallDamageChange;

    private bool moatUpgradeApplied = false;
    private bool pitfallUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(barricade.stats.buildSound);
    }

    void Start()
    {
        moatSlowChange = barricade.stats.slowStrength / 2;
        pitfallDamageChange = 10;
    }

    void Update()
    {
        if (moatUpgradeApplied || pitfallUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("MoatActivated") == isTrue)
        {
            MoatUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("PitfallActivated") == isTrue)
        {
            PitfallUpgradeEnabled();
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemy.stats.speed = enemy.stats.startSpeed / barricade.stats.slowStrength;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.stats.speed = enemy.stats.startSpeed;
            }
        }
    }

    void MoatUpgradeEnabled()
    {
        barricade.stats.slowStrength += moatSlowChange;

        moatUpgradeApplied = true;
    }

    void PitfallUpgradeEnabled()
    {
        barricade.stats.damage += pitfallDamageChange;

        pitfallUpgradeApplied = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, barricade.stats.slowRadius);
    }
}
