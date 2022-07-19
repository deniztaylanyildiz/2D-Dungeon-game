using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidable : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;

    public ContactFilter2D filter;
    private Collider2D[] hits = new Collider2D[10];
    public AudioSource zugzug;
    public AudioSource chestopening;


    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();



    }


    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;


            }
            else
            {
                OnCollide(hits[i]);            
                hits[i] = null;

            }
        }
        
    


    }
    protected virtual void  OnCollide  (Collider2D coll)
    {
        zugzug.Play();

        Debug.Log("Oncollide giriþi olmadý" + this.name);
    }
}


