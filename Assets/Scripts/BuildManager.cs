using UnityEngine;

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
    
    public GameObject ballistaPrefab;
    public GameObject catapultPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild {get{return turretToBuild != null;}}

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("YOU'RE POOR");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built - Money Left:" + PlayerStats.Money);
    }

}
