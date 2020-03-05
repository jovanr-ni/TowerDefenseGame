using UnityEngine;
using System.Collections;

[System.Serializable] // omogucava nam da prikazemo klasu sa razlicitim podacima
                     //  u inspektoru, svaka instanca ove klase ce imati sve ove
                    //   podatke

public class TurretBlueprint 
{
    public GameObject prefab;
    public int        cost;
}
