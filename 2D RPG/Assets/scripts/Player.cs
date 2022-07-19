using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    
    private SpriteRenderer spriteRenderer;
    private Animator run;
    private bool live = true;
    public void heal(int healingAmount)
    {

      
        if (Hitpoint == maxHitpoint)
            return;
        Hitpoint += healingAmount;
        if (Hitpoint > maxHitpoint)
            Hitpoint = maxHitpoint;
            GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnhitpointHitPoint();



    }
    protected override void ReceiveDamage(Damage dmg)
    {
        if (live == false)
        { return; }
        else
        {
            base.ReceiveDamage(dmg);
            GameManager.instance.OnhitpointHitPoint();
        }
    }



    protected override void Start()
    {
        base.Start();
        run = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (live == true)
        {
            UpdateMotor(new Vector3(x, y, 0));

            if ((Input.GetKey("a")) || (Input.GetKey("d")) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow)))
            {
                walk();
            }
            else
            {
                stay();
            }
        }
        
        
    }                  
    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.PlayerSprites[skinId];
    }
 public void OnLVLUP()
    {
        maxHitpoint=2+maxHitpoint;
        Hitpoint = maxHitpoint;

    }
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLVLUP();
        }

    }
    public void walk()
    {



        run.SetBool("run", true);


    }
    public  void stay()
    {
        run.SetBool("run", false);
    }

    protected override void death()
    {
        live = false;
        GameManager.instance.deathMenuanim.SetTrigger("dm_show");
    }
    public void respawn(){
        heal(maxHitpoint);
        live = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
        PlayerPrefs.DeleteAll();
    }
}
