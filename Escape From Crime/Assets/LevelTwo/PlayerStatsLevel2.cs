using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsLevel2 : MonoBehaviour
{
    public int health=6;
    public int lives=3;

    private float flickerTime=0f;
    public float flickerDuration=0.1f;

    private SpriteRenderer spriterenderer;

    public bool isImmune = false;
    private float immunityTime=0f;
    public float immunityDuration=1.5f;

    public int coinsCollected=0;

    void Start()
    {
        spriterenderer=this.gameObject.GetComponent<SpriteRenderer>();
    }

    void SpriteFlicker()
    {
        if(this.flickerTime<this.flickerDuration){
            this.flickerTime=this.flickerTime+Time.deltaTime;
        }
        else if (this.flickerTime>=this.flickerDuration){
            spriterenderer.enabled=!(spriterenderer.enabled);
            this.flickerTime=0;
        }
    }
    
    void Update()
    {
        if(this.isImmune==true){
            SpriteFlicker();
            immunityTime= immunityTime + Time.deltaTime;
            if(immunityTime>=immunityDuration){
                this.isImmune=false;
                this.spriterenderer.enabled=true;
            }
        }
    }

    public void TakeDamage(int damage){
        if (this.isImmune==false){
            this.health=this.health-damage;
            if(this.health<0)
            this.health=0;
            if (this.lives>0 && this.health==0){
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health=6;
                this.lives--;
            }
            else if (this.lives==0 && this.health==0){
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: "+this.health.ToString());
            Debug.Log("Player Lives: "+this.lives.ToString());
        }
        PlayHitReaction();
    }

    void PlayHitReaction(){
        this.isImmune=true;
        this.immunityTime=0f;
    }

}