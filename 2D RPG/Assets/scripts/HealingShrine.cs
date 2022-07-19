using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingShrine : collidable
{
    public int healingAmount = 1;
    private float healColldown = 1.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name != "Player")
            return;
        if (Time.time - lastHeal > healColldown) {

            lastHeal = Time.time;
            GameManager.instance.Player.heal(healingAmount);
        
        }    
    }
}
