using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    // Controller for the Wizard boss.
    // Kinda glitchy tbh, but this was rushed at the end. 
    GameObject player;
    Animator wizAnim;
    AudioSource bossMusic; 
    
    // Timers. 
    float dashTimer = 5;
    float hurtTimer = 5;
    float bulletTimer = 0; 


    int health = 3; // how many times wizard can get hit. 

    bool isAwake = false;
    bool initialTrigger = true; 
   
    //Prefabs
    [SerializeField] GameObject wizExplosion; // Explosion to spawn
    [SerializeField] GameObject bullet;  // Bullet prefab to spawn
    [SerializeField] GameObject portal;
    // End prefab

    // Data points, no gamemanager here, wizards a big boy he can handle himself. 
    [SerializeField] float knockbackForce = 500f;
    [SerializeField] float damageRefresh = 3.5f;

    [SerializeField] float dashAnimationRefresh = 0.5f; 

    [SerializeField] float teleportDistance = 10f;

    [SerializeField] float bulletRate = 2f;

    [SerializeField] float dashRefresh = 1.5f;

    [SerializeField] PopupText txt; 

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // retrieve ducky. 
        wizAnim = gameObject.GetComponent<Animator>(); // The wizards animation controller. 
        bossMusic = gameObject.GetComponent<AudioSource>(); 
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAwake = true;
            if(initialTrigger)
            {   
                 txt.Show("'You never should have come here Ducky...'-The Wizard");
                bossMusic.Play();
                SoundManager.PlaySound(SoundType.LAUGH);
                bulletTimer = 0; // On initial trigger, wait a bit to start firing bullets. 
                initialTrigger = false; 
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Nothing need yet, I dont want the wizard to ever sleep once awoken. he fights until the end. 
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * knockbackForce);//knockback jinx
            if(hurtTimer >= damageRefresh) // hurtwait
            {
                Hurt();
                //hurtTimer = 0; // Reset hurt timer. 
            } 
        }
    }

    void Dash()
    {
        gameObject.GetComponent<Animator>().SetBool("isDash", true); // set dash animation
        // Obtain the positions of both player and wizard. 
        Vector2 playerPos = player.transform.position;
        Vector2 wizPos = gameObject.transform.position;

        // Randomly teleport the wizard within a certain range. 
        SpawnPortal(); // Spawn a portal. 
        wizPos.x = playerPos.x + (Random.Range(5f, teleportDistance));
        wizPos.y = playerPos.y + (Random.Range(1f, 3f));
        gameObject.transform.position = wizPos;
    }

    void Hurt()
    {
        health--;
        SoundManager.PlaySound(SoundType.LAUGH); // Play a laugh. 
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;  // CHANGE COLOR. //signifying damange
        Vector2 pos = player.transform.position;

        if (health <= 0)
        {
            DestroyWizard();
        }
        
        hurtTimer = 0; // Reset hurt timer. 
    }

    void DestroyWizard()
    {
        Vector2 pos = gameObject.transform.position;
        var r = gameObject.transform.rotation;
        Instantiate(wizExplosion, pos, r);
        txt.Show("You haven't seen the last of us Ducky...we will be watching.");
        if (wizExplosion)
        {
            Destroy(gameObject);
        }
    }

    void SpawnBullet()
    {
        Vector2 pos = gameObject.transform.position;
        var r = gameObject.transform.rotation;
        Instantiate(bullet, pos, r);
        bulletTimer = 0;
    }
    
    void SpawnPortal()
    {
        Vector2 pos = gameObject.transform.position;
        var r = gameObject.transform.rotation;
        Instantiate(portal, pos, r); 
    }
    
    void FixedUpdate()
    {
        // is it messy yes.
        // am I refactoring it, no. 
        if(dashTimer >= dashAnimationRefresh) 
        {
            gameObject.GetComponent<Animator>().SetBool("isDash", false); // Stop dash animation. 
        }
        if (isAwake && dashTimer >= dashRefresh)
        {   
            //Reset and dash
            dashTimer = 0;
            Dash();
        }

        if (isAwake && bulletTimer >= bulletRate)
        {
            // Spawn another bullet, hence the rate timer. 
            SpawnBullet();
            // Play a sound effect here vs dash, because bulletRate has the longer cooldown, and i dont want to spam sounds.
            SoundManager.PlaySound(SoundType.WIZARD);
        }

        // Clock timers.
        dashTimer += Time.fixedDeltaTime;
        hurtTimer += Time.fixedDeltaTime;
        bulletTimer += Time.fixedDeltaTime; 

        if(hurtTimer >= damageRefresh) // CAN MODIFY TO CHANGE REFRESH RATE OF DAMAGE TIMER
        {   
            // This visualizesresets the wizard so he can take damage again. 
            // But don't actually call Hurt until hit again. 
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;  // CHANGE COLOR back to standard after 5. 
        } 
    }
}
