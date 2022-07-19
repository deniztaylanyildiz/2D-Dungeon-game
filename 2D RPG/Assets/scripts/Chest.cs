using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : collectable
{
    public Sprite emtychest;
    public int goldinchest=5;




    protected override void oncollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emtychest;
            GameManager.instance.gold += goldinchest;
            GameManager.instance.ShowText("+" + goldinchest + "gold",25,Color.yellow,transform.position,Vector3.up*50,3.0f);
            chestopening.Play();
        }

       
    }
}
