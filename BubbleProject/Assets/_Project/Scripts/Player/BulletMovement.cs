using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    private Quaternion direction;  // Direction the bullet will travel in
    private float lifetime = 2f;  // Lifetime of the bullet before it is destroyed

    private GunMovement gun;
    private Rigidbody2D physics;


    void Start()
    {
        this.gun = transform.parent.GetComponent<GunMovement>();
        physics = GetComponent<Rigidbody2D>();

        direction = this.gun.current_direction;
        Vector2 directionVector = direction * Vector2.right; 
        physics.velocity = directionVector * speed;  


        Destroy(gameObject, lifetime);
    }
}
