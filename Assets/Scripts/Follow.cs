using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;      // The sprite to follow
    public float speed = 5f;      // Follow speed
    public bool smooth = true;    // Whether to move smoothly

    void Update()
    {
        if (target == null) return;

        if (smooth)
        {
            // Smooth follow
            transform.position = Vector3.Lerp(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
        else
        {
            // Instant follow
            transform.position = target.position;
        }
    }
}