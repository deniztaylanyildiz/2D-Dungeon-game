using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_0 : enemy
{
    public float[] firEballspeed = { 2.5f ,-2.5f};
    public Transform[] fireballs;
    public float distance = 0.25f;


    private void Update()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {

        
        
            fireballs[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * firEballspeed[i]) * distance, Mathf.Sin(Time.time * firEballspeed[i]) * distance, 0);
        }
        
    }
}
