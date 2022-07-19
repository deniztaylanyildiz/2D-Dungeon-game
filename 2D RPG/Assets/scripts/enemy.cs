using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : Mover
{
    //exp
    public int xpvalue;
    public int hp=10;
    //logic
    public float triggerlenght=1;
    public float chaselenght=5;
    public bool chasing;
    private bool collidingWithPlayer;
    private Transform playertransform;
    private Vector3 startingPosition;
     public Animator door;
   
    
    

    //hitbox
    public  BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    public ContactFilter2D filter;

    protected override void Start()
    {
        base.Start();
        playertransform = GameManager.instance.weapon.transform;
        startingPosition = transform.position;
        



    }
    protected void FixedUpdate()
    {
        
        if (Vector3.Distance(playertransform.position, startingPosition) < chaselenght)
        {
            if (Vector3.Distance(playertransform.position, startingPosition) < triggerlenght)
                chasing = true;

            if (chasing)
            {
                if(!collidingWithPlayer)
                {

                    UpdateMotor((playertransform.position - transform.position).normalized);


                }
                

            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }

        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }
    
        //check for ovelaps
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;


            }
            else
            {
               if(hits[i].tag=="Fighter"&&hits[i].name=="Player")
                {
                    collidingWithPlayer = true;
                }
                hits[i] = null;

            }
        }
    }
    protected override void death()
    {

        

        if (name == "BOOS_1")
        {
            door.SetTrigger("open");

            Destroy(gameObject);
            GameManager.instance.GrandXP(xpvalue);
            GameManager.instance.ShowText("+" + xpvalue + "xp", 25, Color.blue, transform.position, Vector3.up * 50, 3.0f);
        }
        else
        {

            Destroy(gameObject);
            GameManager.instance.GrandXP(xpvalue);
            GameManager.instance.ShowText("+" + xpvalue + "xp", 25, Color.blue, transform.position, Vector3.up * 50, 3.0f);

        }
    }
}
