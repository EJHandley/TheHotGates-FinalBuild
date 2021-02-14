using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBallista()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseCatapult()
    {
        buildManager.SetTurretToBuild(buildManager.secondTurretPrefab);
    }

    public void PurchaseSpartan()
    {
        
    }

    public void PurchaseStoneWall()
    {

    }

}
