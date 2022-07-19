

using UnityEngine.UI;
using UnityEngine;
public class Floatingtext 
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;
         

    public void show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(true);

    }

   

    public void hide()
    {
        active = false;
        go.SetActive(active);

    }
    public void UpdateFloatingText()
    {
        if (!active)
            return;


        if (Time.time - lastShown > duration)
 
           hide();
        go.transform.position += motion * Time.deltaTime;
    }
}
