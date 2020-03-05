using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 70f;
    public GameObject prefabImpact;
    public float ExplosionRadius=0f;
    public int damage = 50;

    private Transform target;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {   
        GameObject prefab= Instantiate(prefabImpact, transform.position, transform.rotation);
        Destroy(prefab, 2f);
   

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        //Physics.OverlapSphere(transform.position, ExplosionRadius)
       //pravi sferu oko date pozicije sa datim radijusom zatim
      //proverava da li se neki game object nalazi u datoj sferi
     //dalje filtriramo preko Collider-a sa datim Tagom inace bi 
    //srusili sve ostale gameObjekte koje sfera preklapa

        Collider[] coliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

        foreach (Collider collider in coliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) 
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.takeDamage(damage);

        }
        
    }

}
