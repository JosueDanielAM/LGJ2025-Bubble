using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Shoted");
            Destroy(gameObject);
        }
        if (other.collider.CompareTag("Wall"))
        {
            Debug.Log("Shoted");
            Destroy(gameObject);
        }
    }
}
