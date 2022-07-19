using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmyhitbox : collidable
{
    //damage
    public int damagepoint = 1;
    public float pushforce=5f;


    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "fighter"&& coll.name == "Player")
        {



            //bir damage objesi oluþtur sonra fightera yolla
            Damage dmg = new Damage
            {
                DamageAmount = damagepoint,
                origin = transform.position,
                pushForce = pushforce

            };
            coll.SendMessage("ReceiveDamage", dmg);
            Debug.Log(coll.name);

        }


    }

}

