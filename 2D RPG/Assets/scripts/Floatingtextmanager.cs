using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floatingtextmanager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    private List<Floatingtext> floatingtexts = new List<Floatingtext>();

    public void Start()
    {
    }
    public void Update()
    {
        foreach (Floatingtext txt in floatingtexts)
            txt.UpdateFloatingText();
    }







    public void Show(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        Floatingtext floatingtext = GetFloatingText();
        floatingtext.txt.text = msg;
        floatingtext.txt.fontSize = fontsize;
        floatingtext.txt.color = color;
        floatingtext.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingtext.motion = motion;
        floatingtext.duration = duration;
        floatingtext.show();
    }


    private Floatingtext GetFloatingText()
    {
        Floatingtext txt = floatingtexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new Floatingtext();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();
            floatingtexts.Add(txt);



        }
        return txt;

    }
}
