using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.5f;
    [SerializeField]
    public Rigidbody2D rigibody;
    private Vector2 movement;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(
            InputManager.first_player_movement.x,
            InputManager.first_player_movement.y);

        this.rigibody.velocity = movement * speed;
    }
}
