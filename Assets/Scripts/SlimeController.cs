using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : MonoBehaviour
{   
    // Controlling script for all slime enemies and variant types.

    // Jumpy is a static slime that jumps in place.
    // Slimy on the other hand "moves" around by bouncing, using updating forces.  
    CrashDetector crashDetector;
    Vector3 slimePos;

    Rigidbody2D slimeBod;

    float t = 1;

    string slimeTag; 

    void Start()
    {
        slimePos = transform.position;
        slimeBod = gameObject.GetComponent<Rigidbody2D>();
        slimeTag = gameObject.tag; 

        if (slimeTag == "Jumpy")
        {
            slimeBod.AddRelativeForce(Vector2.down * DataManager.I.GetSlimeJump());
        }

    }

    void FixedUpdate()
    {
        if (slimeTag == "Slimy")
        {
            UpdateSlimy();
        }
    }
    
    void UpdateSlimy()
    {
        t += Time.deltaTime; 
        if(t >= DataManager.I.GetSlimeRefresh())
        {
            Attack(); 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Board")
        {   
            // Crash detector handles player side of things. 
            crashDetector = other.gameObject.GetComponent<CrashDetector>();
            crashDetector.ExplodeDucky();
            // Set animator of slime to death anim
            //gameObject.GetComponent<Animator>().SetBool("SlimeDead", true);
            //DestroySlime();
        }
    }
    
    void Jump()
    {
        // Calculate a jump force multiplied by data manager. 
        slimeBod.AddRelativeForce(Vector2.down * DataManager.I.GetSlimeJump());
    }

    void Attack()
    {
        // The "AI" (not really) for the standard slime variant. 
        t = 0;
        DataManager dm = DataManager.I;
        Vector2 jumpForce = Vector2.up * dm.GetSlimeDrag();
        Vector2 brakeForce = Vector2.left * dm.GetSlimeMove(); 
        slimeBod.AddForce(jumpForce); 
        slimeBod.AddForce(brakeForce);
    }

    public void DestroySlime()
{
    // Add the current slime to an excluded layer (can no longer collide with player)
    gameObject.layer = LayerMask.NameToLayer("Exclude");

    // Play death animation.
    GetComponent<Animator>().SetBool("SlimeDead", true);

    // Play slime sound. 
    SoundManager.PlaySound(SoundType.SLIME); 
    
    // Schedule destruction.
    Invoke(nameof(DelayedDestroy), DataManager.I.GetSlimeDelay());
}
    
    void DelayedDestroy()
    {
        Destroy(gameObject);
    }
}
