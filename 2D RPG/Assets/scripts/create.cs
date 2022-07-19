using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : Fighter
{
    public AudioSource broke;
    protected override void death()
    {
        Destroy(gameObject);
        broke.Play();
    }


  
}

