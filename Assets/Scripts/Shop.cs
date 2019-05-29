using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluepriont stamdardTurret;
    public TurretBluepriont cannon;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("kupiłeś wieze");
        buildManager.SelectTurretToBuild(stamdardTurret);
    }

    public void SelectCannon()
    {
        Debug.Log("kupiłeś wieze 2");
        buildManager.SelectTurretToBuild(cannon);

    }
}
