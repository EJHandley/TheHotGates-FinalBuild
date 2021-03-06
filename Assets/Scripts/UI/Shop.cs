using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint arcadianSpearman;
    public TurretBlueprint spartanHoplite;
    public TurretBlueprint helotArcher;
    public TurretBlueprint ballista;
    public TurretBlueprint catapult;

    public TurretBlueprint ditch;
    public TurretBlueprint woodenWall;
    public TurretBlueprint stoneWall;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcadian()
    {
        buildManager.SelectTurretToBuild(arcadianSpearman);
    }

    public void SelectSpartan()
    {
        buildManager.SelectTurretToBuild(spartanHoplite);
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(helotArcher);
    }

    public void SelectBallista()
    {
        buildManager.SelectTurretToBuild(ballista);
    }

    public void SelectCatapult()
    {
        buildManager.SelectTurretToBuild(catapult);
    }

    public void SelectDitch()
    {
        buildManager.SelectTurretToBuild(ditch);
    }

    public void SelectWoodenWall()
    {
        buildManager.SelectTurretToBuild(woodenWall);
    }

    public void SelectStoneWall()
    {
        buildManager.SelectTurretToBuild(stoneWall);
    }

}
