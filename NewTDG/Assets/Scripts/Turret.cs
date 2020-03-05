using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
     


    [Header("Unity Setup Fileds")]
    public Transform partToRotate;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 10f;
    private Transform target;
    
    public Transform firePoint;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation,Time.deltaTime*rotationSpeed).eulerAngles;
        partToRotate.localRotation = Quaternion.Euler(0f,rotation.y,0f);
        //pretvaranje se vrsi iz razloga sto zelimo da postignemo
        // rotaciju samo oko y-ose 
        //  lerp vrsi smooth rotaciju od tacke A do tacke B za vreme T


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

     void Shoot()
    {
      GameObject bulletGO=(GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
      Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else { target = null; }

    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
