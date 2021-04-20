using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public bool turretSelected;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More Than One BuildManager In Scene");
            return;
        }
        instance = this;
    }

    [HideInInspector]
    public TurretStats turretToBuild;

    public bool CanBuild {get{return turretToBuild != null;}}

    public void SelectTurretToBuild(TurretStats turret)
    {
        turretSelected = true;
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.NormalCurrency < turretToBuild.purchaseValue)
        {
            return;
        }

        PlayerStats.NormalCurrency -= turretToBuild.purchaseValue;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.Euler(0f, 180f, 0f));
        node.turret = turret;
    }

}
