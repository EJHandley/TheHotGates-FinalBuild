﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{

    public int normalValue;
    public int specialValue;

    public float startHealth;
    public float health;
    public int startDamage;
    public int damage;

    public float startSpeed;
    public float speed;

    public float attackRange;
    public float attackSpeed;
    public float attackReset;

    public Transform rotationPoint;
    public float turnSpeed;

    public float reachedObjective;

}
