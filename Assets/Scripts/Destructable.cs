using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject vfx;
    
    public virtual void Detroy()
    {
        Instantiate(vfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
