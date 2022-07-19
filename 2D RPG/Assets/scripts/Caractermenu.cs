using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caractermenu : MonoBehaviour
{
    public Text lvlText, HitpointText, goldtext, upgradeCostText, xpText;
    //logic
    private int currentCharactersellection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpbar;

    //caracterselection

    public void Update()
    {
        UpdateMenu();
    }
    public void Onarrowclick(bool right)
    {
        if(right)
        {
            currentCharactersellection++;
            if (currentCharactersellection == GameManager.instance.PlayerSprites.Count)
                currentCharactersellection =0;
            Onselectionchanged();
        }
        else
        {
            currentCharactersellection--;
            if (currentCharactersellection < 0)
                currentCharactersellection = GameManager.instance.PlayerSprites.Count - 1;
            Onselectionchanged();
        }

    }
    private void Onselectionchanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.PlayerSprites[currentCharactersellection];
        GameManager.instance.Player.SwapSprite(currentCharactersellection);

    }

    //weapon Upgrade

    public void onclickUpgrade()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();   
        
    }
    //update caracter informations
    public void UpdateMenu()
    {

        // weapon
        weaponSprite.sprite = GameManager.instance.WeoponSprites[GameManager.instance.weapon.weoponlvl];
        if (GameManager.instance.weapon.weoponlvl == GameManager.instance.weoponprices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weoponprices[GameManager.instance.weapon.weoponlvl].ToString();
        //meta
        lvlText.text = GameManager.instance.GetCurrentLVL().ToString();
        //hp
        HitpointText.text = GameManager.instance.Player.Hitpoint.ToString();
        //gold
        goldtext.text = GameManager.instance.gold.ToString();

        //xp bar
        int currentlvlxp = GameManager.instance.GetCurrentLVL();
        if (currentlvlxp == GameManager.instance.xptable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + "total exp point";//display total exp
            xpbar.localScale = Vector3.one;
            xpText.text = "MAX LEVEL";
        }
        
        else
        {
            int prevlvlxp = GameManager.instance.getxptolvl(currentlvlxp - 1) ;
            int currlvlxp = GameManager.instance.getxptolvl(currentlvlxp);
            int diff = currlvlxp - prevlvlxp;
            int currexpIntolevel = GameManager.instance.experience - prevlvlxp ;
            float complateratio = (float)currexpIntolevel / (float)diff;
            xpbar.localScale = new Vector3(complateratio, 1, 1);
            xpText.text = currexpIntolevel.ToString() + "/" + diff;
        }
     

    }
}
