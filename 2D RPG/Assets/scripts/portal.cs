using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : collidable
{
    public string[] scenenames;
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name=="Player")
        {
            //teleport random dungeon
            GameManager.instance.SaveState();
            string teleport = scenenames[Random.Range(0, scenenames.Length)];
            SceneManager.LoadScene(teleport);
        }
    }
}
