using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Destructable
{
    public int damage = 20;
    public float range = 3;
    
    public override void Detroy()
    {
        //find all health & deal damage if in range
        var healths = FindObjectsOfType<Health>();
        foreach (var health in healths)
        {
            if (Vector3.Distance(health.transform.position, transform.position) < range)
                health.TakeDamage(damage);
        }
        
        base.Detroy();
    }
}
