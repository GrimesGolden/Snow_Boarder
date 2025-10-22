using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyController : MonoBehaviour
{
    SlimeController parentScript;

    void Start()
    {
        parentScript = gameObject.GetComponentInParent<SlimeController>(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Board")
        {
            other.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 500); // bouncy
            parentScript.DestroySlime(); 
        }
    }
}
