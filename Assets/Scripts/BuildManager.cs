﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More Than One BuildManager In Scene");
            return;
        }
        instance = this;
    }

    private TurretStats turretToBuild;

    public bool CanBuild {get{return turretToBuild != null;}}

    public void SelectTurretToBuild(TurretStats turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.NormalCurrency < turretToBuild.purchaseValue)
        {
            Debug.Log("YOU'RE POOR");
            return;
        }

        PlayerStats.NormalCurrency -= turretToBuild.purchaseValue;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built - Money Left:" + PlayerStats.NormalCurrency);
    }

}
