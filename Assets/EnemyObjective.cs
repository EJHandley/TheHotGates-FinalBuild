using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjective : MonoBehaviour
{
    #region Singleton

    public static EnemyObjective instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject enemyObjective;

}
