using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint ballista;
    public TurretBlueprint catapult;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBallista()
    {
        buildManager.SelectTurretToBuild(ballista);
    }

    public void SelectCatapult()
    {
        buildManager.SelectTurretToBuild(catapult);
    }

    public void PurchaseSpartan()
    {
        
    }

    public void PurchaseStoneWall()
    {

    }

}
