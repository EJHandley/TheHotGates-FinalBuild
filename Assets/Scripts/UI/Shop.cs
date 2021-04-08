using UnityEngine;

public class Shop : MonoBehaviour
{
    public ArcadianController arcadian;
    public SpartanController spartan;
    public ArcherController archer;
    public BallistaController ballista;
    public CatapultController catapult;

    public DitchController ditch;
    public WoodenWallController woodenWall;
    public StoneWallController stoneWall;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcadian()
    {
        buildManager.SelectTurretToBuild(arcadian.turret.stats);
    }

    public void SelectSpartan()
    {
        buildManager.SelectTurretToBuild(spartan.turret.stats);
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(archer.turret.stats);
    }

    public void SelectBallista()
    {
        buildManager.SelectTurretToBuild(ballista.turret.stats);
    }

    public void SelectCatapult()
    {
        buildManager.SelectTurretToBuild(catapult.turret.stats);
    }

    public void SelectDitch()
    {
        buildManager.SelectTurretToBuild(ditch.barricade.stats);
    }

    public void SelectWoodenWall()
    {
        buildManager.SelectTurretToBuild(woodenWall.barricade.stats);
    }

    public void SelectStoneWall()
    {
        buildManager.SelectTurretToBuild(stoneWall.barricade.stats);
    }

}
