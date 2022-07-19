using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramotor : MonoBehaviour
{
    // kamera takibi

    private Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    public void Start()
    {
        lookAt = GameObject.Find("Player").transform;
    }
    public void LateUpdate()
    {
        // x için yapýlan
        Vector3 delta = Vector3.zero;
        float deltax = lookAt.position.x - transform.position.x;
        if(deltax>boundX || deltax< -boundX)
        {
          if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltax - boundX;
            }
          else
            {
                delta.x = deltax + boundX;
            }

        }
        // y için yapýlan 
         float deltay = lookAt.position.y - transform.position.y;
        if (deltay > boundY || deltay < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltay - boundY;
            }
            else
            {
                delta.y = deltay + boundY;
            }


        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

}
