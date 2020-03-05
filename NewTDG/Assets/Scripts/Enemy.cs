
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    public int   health  = 100;
    public int moneyValue = 50;
    public GameObject deathEffect;
    
    private Transform target;
    private int index = 0;

    public void takeDamage(int amaount) {

        this.health -= amaount;
        
        if (health <= 0) 
            {
                Die();
            }
    }


    public void Die() { Destroy(gameObject); PlayerStats.Money += moneyValue; Instantiate(deathEffect, transform.position, transform.rotation); }

    void Start()
    {
        target =Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void GetNextWaypoint()
    {
        if (index >= Waypoints.points.Length - 1)
        {
            EndPath();

            Destroy(gameObject);
            return;
        }

        index++;
        target = Waypoints.points[index].transform;

    }

    private void EndPath()
    {
        PlayerStats.Lives--;
    }
}
