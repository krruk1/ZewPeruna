using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color possitiveColor;
    public Color negativeColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

  

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.CanBuild)
        {
            return;
        }


        if (turret != null)
        {
            Debug.Log("Wieża już stoi");
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        else
        {
            rend.material.color = possitiveColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

}
