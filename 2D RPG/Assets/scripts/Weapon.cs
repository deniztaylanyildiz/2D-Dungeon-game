using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : collidable
{
    //damage
    public int[] damagepoint = {1, 2, 3, 4, 5, 6, 7};
    public float[] pushforce = { 2.0f, 2.1f, 2.2f, 2.3f, 2.4f, 2.5f, 2.6f };
    //upgrade
    public int weoponlvl = 0;
    public  SpriteRenderer Spriterenderer;
    //swing
    private float cooldown = 0.5f;
    private float lastswing;
    private Animator anim;
    public AudioSource swordswing;
    private void Awake()
    {
        Spriterenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();

        Spriterenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
            {
            if(Time.time-lastswing>cooldown)
            {
                lastswing = Time.time;
                swing();
            }

        }
    }


    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag=="fighter")
        {
            if (coll.name == "Player")
                return;


            //bir damage objesi oluþtur sonra fightera yolla
            Damage dmg   = new Damage 
            {
                DamageAmount = damagepoint[weoponlvl],
                origin = transform.position,
                pushForce=pushforce[weoponlvl]

            };
            coll.SendMessage("ReceiveDamage", dmg);
                
            
        }
        

    }
    private void swing() 
    {

        anim.SetTrigger("swing");
        swordswing.Play();
    }
    public void upgradeWeapon()
    {
        weoponlvl++;
        Spriterenderer.sprite = GameManager.instance.WeoponSprites[weoponlvl];
    }

    public void SetWeaponLVL(int level)
    {
        weoponlvl = level;
        Spriterenderer.sprite = GameManager.instance.WeoponSprites[weoponlvl];


    }
    //chance  stats
}
