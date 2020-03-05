using UnityEngine;
using UnityEngine.EventSystems;
public class Nodes : MonoBehaviour
{
    [Header("Attributes")]
    public Color hoverColor;
    public Color notAllowed;
    public Vector3 PositionOffset;

    
    private Renderer rend;
    private Color startColor;
    private bool YesNoTurret = false;
    [Header( "Optional")]
    public GameObject turret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }




    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (YesNoTurret == true)
        {
            rend.material.color = notAllowed;
            return;
        }

        if (!buildManager.HasMoney)
        {
            rend.material.color = notAllowed;
            return;


        }
        else
        {
            rend.material.color = hoverColor;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor ;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        buildManager.BuildTurretOn(this);
        YesNoTurret = true;
        rend.material.color = notAllowed;
        return; 
    }

    public Vector3 GetBuildPosition()
    {
        return (transform.position + PositionOffset);
    }

}
