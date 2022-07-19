using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zugzug : collidable
{
    public string text;
    private float cooldown = 4.0f;
    private float lastshout = -4.0f;



    
    protected override void OnCollide(Collider2D coll)
   
    {
        if (Time.time - lastshout > cooldown)
        {
            lastshout = Time.time;

            GameManager.instance.ShowText(text, 25, Color.white, transform.position+new Vector3(0,0.16f,0), Vector3.zero, cooldown);
        }        
        
    }
}
