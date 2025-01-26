using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            Debug.Log("Destroyed");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
