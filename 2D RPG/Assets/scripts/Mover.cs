using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    private BoxCollider2D boxCollider2D;
    private Vector3 movedelta;
    private RaycastHit2D hit;
    public float ySpeed = 0.75f;
    public float Xspeed = 1.0f;
    protected virtual void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>(); 
    }
   

   

        protected virtual void UpdateMotor(Vector3 input)
    {

        movedelta = new Vector3(input.x*Xspeed,input.y*ySpeed,0); 
        // -yön deðiþtirme saða sola gitme-

        if (movedelta.x > 0)

            transform.localScale = Vector3.one;


        else if (movedelta.x < 0)

            transform.localScale = new Vector3(-1, 1, 1);


        //add push force, if any
        movedelta += pushDirection;
        //reduce push force every frame, based off recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);




        //duvar çarpmasý köþeler //duvara çarpýnca açýsal olarak durmak
        //(y için)
        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(0, movedelta.y), Mathf.Abs(movedelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //haraket kýsmý
            transform.Translate(0, movedelta.y * Time.deltaTime, 0);

        }
        //x için
        hit = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, new Vector2(movedelta.x, 0), Mathf.Abs(movedelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //haraket kýsmý
            transform.Translate(movedelta.x * Time.deltaTime, 0, 0);

        }

    }


    
}
