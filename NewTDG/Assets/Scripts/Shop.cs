using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public  TurretBlueprint  standardTurret;
    public  TurretBlueprint  missileLauncher;
    public  TurretBlueprint  laserBeamer;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandradTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
        
    }
 
    public void SelectMissleTurret()
    {
        Debug.Log("Purchase Missle Turret");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
        
    public void SelectLaserBeamer() 
    {
            Debug.Log("Purchase Missile Turret");
            buildManager.SelectTurretToBuild(laserBeamer);
    }
    

    
}
