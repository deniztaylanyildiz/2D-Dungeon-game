using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour

{
    public BoxCollider2D doorcollider;
    public Sprite dooropened;
    public bool control = true;

    public void Start()
    {
        doorcollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        if(control == false)
        {
            GetComponent<SpriteRenderer>().sprite = dooropened;
            doorcollider.enabled = false;

        }
        else
        {
            return;
        }
    }


}
