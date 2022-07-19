using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    // Start is called before the first frame update
  
    private void Awake()
    {
        if(GameManager.instance!=null)
        {
            Destroy(gameObject);
            Destroy(Player.gameObject);
            Destroy(floatingmanager.gameObject);
            Destroy(hud.gameObject);
            Destroy(menu.gameObject);
            
            return;
                 
        }
      

        instance = this;
        SceneManager.sceneLoaded += LoadState;


        
    }
    //ressources
    public List<Sprite> PlayerSprites;
    public List<Sprite> WeoponSprites; 
    public List<int> weoponprices;
    public List<int> xptable;
    public Floatingtextmanager floatingmanager;
    public AudioSource  LVLUPP;
    public RectTransform HitpointBar;
    //References
    public Player Player;
    //logic
    public int gold;
    public int experience;
    public Weapon weapon;
    public GameObject hud;
    public GameObject menu;
    public GameObject voiceLVLUP;
    public Animator deathMenuanim;


    public void OnhitpointHitPoint()
    {
        float ratio = (float)Player.Hitpoint / (float)Player.maxHitpoint;
        HitpointBar.localScale = new Vector3(1, ratio, 1);
    }
    public void ShowText(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingmanager.Show(msg, fontsize, color, position, motion, duration);
       
    }
    public bool TryUpgradeWeapon()
    {
        //weapon max
        if (weoponprices.Count <=weapon.weoponlvl)
            return false;
        if (gold>=weoponprices[weapon.weoponlvl])
        {
            gold -= weoponprices[weapon.weoponlvl];
            weapon.upgradeWeapon();
            return true;
        }
        return false;
    }
   


    //exp system


    public int GetCurrentLVL()
    {
        int r = 0;
        int add = 0;
        while(experience>=add)
        {
            add += xptable[r]; ;
            r++;
            if (r == xptable.Count)//maxlvl
                return r;
        }
        return r;

    }
    public int getxptolvl(int level)
    {
        int r = 0;
        int xp = 0;
        while (r<level)
        {
            xp += xptable[r];
            r++;
        }
        return xp;
    }
    public void GrandXP(int xp)
    {
        int currlevel = GetCurrentLVL();
        experience += xp;
        if (currlevel < GetCurrentLVL())
            Onlvlup();
    }
    public void Onlvlup()
    {
        Debug.Log("lvl UP");
        Player.OnLVLUP();
        GameManager.instance.ShowText("LVL UP", 25, Color.white, transform.position, Vector3.up * 50, 3.0f);
        LVLUPP.Play();
        HitpointBar.localScale = new Vector3(1, 1, 1);
    }
    //save state

    public void SaveState()
    {
        Debug.Log("saved");
        string s = "" ;
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weoponlvl.ToString();
        PlayerPrefs.SetString("SaveState", s);
        Player.transform.position = GameObject.Find("Spawnpoint").transform.position;

    }
    public void LoadState(Scene s,LoadSceneMode mode)
    {
        

        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        SceneManager.sceneLoaded -= LoadState;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
            gold = int.Parse(data[1]);
           //experince    
        experience = int.Parse(data[2]);
         if(GetCurrentLVL()!=1)
        Player.SetLevel(GetCurrentLVL());
        weapon.SetWeaponLVL( int.Parse(data[3]));
        Debug.Log("loaded");
        Player.transform.position = GameObject.Find("Spawnpoint").transform.position;

    }
    
    public void menu_stop ()
    {
        Time.timeScale = 0;

    }
    public void menu_start()
    {

        Time.timeScale = 1;

    }

    //deathMenu and respawn
    public void Respawn()
    {
        deathMenuanim.SetTrigger("dm_hide");
        UnityEngine.SceneManagement.SceneManager.LoadScene("dungeon_0");
        Player.respawn();
         PlayerPrefs.DeleteAll(); //delete 

    }
  
}
 