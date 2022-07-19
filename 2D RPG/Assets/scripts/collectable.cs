using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : collidable
{
    protected bool collected;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            oncollect();

    }
    protected virtual void oncollect()
    {
        collected = true;

    }
}
