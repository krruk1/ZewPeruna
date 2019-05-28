using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBluepriont turretToBuild;

    private void Awake()
    {
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject cannonPrefab;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluepriont turret)
    {
        turretToBuild = turret;
    }
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("moło hajsu");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition() , Quaternion.identity);
        node.turret = turret;
    }
}
