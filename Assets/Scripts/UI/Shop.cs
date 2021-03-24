using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretStats arcadianSpearman;
    public TurretStats spartanHoplite;
    public TurretStats helotArcher;
    public TurretStats ballista;
    public TurretStats catapult;

    public TurretStats ditch;
    public TurretStats woodenWall;
    public TurretStats stoneWall;

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
