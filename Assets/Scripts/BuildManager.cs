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

    [Header("Attacking Units")]
    public GameObject arcadianPrefab;
    public GameObject spartanPrefab;
    public GameObject archerPrefab;
    public GameObject ballistaPrefab;
    public GameObject catapultPrefab;

    [Header("Defensive Buildings")]
    public GameObject ditchPrefab;
    public GameObject woodenWallPrefab;
    public GameObject stoneWallPrefab;

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
