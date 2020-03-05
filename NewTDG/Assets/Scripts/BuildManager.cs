using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Attributes")]
    public static BuildManager    instance;
    public GameObject buildEffect;
    private Vector3 offsetEffect= new Vector3(1.5f, 0f, 0f);
    
    private       TurretBlueprint turretToBuild;

    private void Awake()
    {if(instance != null)
        {
            Debug.Log("More than one Build Manager in scene!");
            return;
        }
        instance = this;
    }

 
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void BuildTurretOn(Nodes node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret =(GameObject)Instantiate(turretToBuild.prefab,node.GetBuildPosition(),Quaternion.identity);//Quaternion.identity ne rotira 
        node.turret = turret;
        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
        GameObject effect = (GameObject)Instantiate(this.buildEffect, node.GetBuildPosition()-offsetEffect,Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {


        this.turretToBuild = turret;
    }

}
