using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour
{
    float t = 0;
    const float explosionLifetime = 1.5f; //dataManager is doing enough work. This can just hang out here. 

    void FixedUpdate()
    {
        t += Time.deltaTime;

        if(t >= explosionLifetime) // If you believe IN MAGIC!
        {
            Destroy(gameObject);
        }

    }
}
