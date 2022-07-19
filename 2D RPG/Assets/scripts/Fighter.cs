using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //public fields
    public int Hitpoint=10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    //immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;
    //push 
    protected Vector3 pushDirection;
    //all figters can ReceiveDamage/die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time-lastImmune>immuneTime)
        {
            lastImmune = Time.time;
            Hitpoint -= dmg.DamageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.DamageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (Hitpoint <= 0)
            {
                Hitpoint = 0;
                death();

            }
        }


    }
    protected virtual void death()
    {



    }
}
