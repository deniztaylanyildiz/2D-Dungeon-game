using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC0 : collidable
    
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.name=="player")
        {
            
            zugzug.Play();
        }
    }
    
}
