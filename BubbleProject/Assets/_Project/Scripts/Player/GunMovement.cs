using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GunMovement : MonoBehaviour
{
    /* public fields */
    [SerializeField]
    public float bullet_speed = 10;
    public GameObject bullet_prefab;
    public Quaternion current_direction;
    /* private fields */
    private PlayerMovement player;

    void Start()
    {
        this.player = transform.parent.GetComponent<PlayerMovement>();
    }

    /* Unity functions */
    void Update()
    {
        this.update_direction_arrow();
    }

    /* Update the local position of the gun respect to the player */
    void update_direction_arrow()
    {
        /*
         * Si se desea que el arma desaparezca cuando el jugador este idle
        if (player.idle == true)
        {
            transform.localPosition = new Vector2(0, 0);
        }
        else
        {
            //los 4 ifs
        }
        */
        if (player.current_direction_string == "Right")
        {
            transform.localPosition = new Vector2(1.4f, 0);
            this.current_direction = Quaternion.Euler(0, 0, 0);
        }
        if (player.current_direction_string == "Left")
        {
            transform.localPosition = new Vector2(-1.4f, 0);
            this.current_direction = Quaternion.Euler(0, 180, 0);
        }
        if (player.current_direction_string == "Up")
        {
            transform.localPosition = new Vector2(0, 1.4f);
            this.current_direction = Quaternion.Euler(0, 0, 90);
        }
        if (player.current_direction_string == "Down")
        {
            transform.localPosition = new Vector2(0, -1.4f);
            this.current_direction = Quaternion.Euler(0, 0, -90);
        }
    }
    /* Function that hanlde the Unity event that read the Shoot action */
    public void capture_shooting(InputAction.CallbackContext context)
    {
        if (context.performed && !this.player.is_stunned && this.player.bubble_charges > 0)
        {
            this.player.bubble_charges--;
            GameObject bullet = Instantiate(this.bullet_prefab, transform.position, this.current_direction);

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            Vector2 velocity = this.current_direction * Vector2.right * this.bullet_speed; 
            bulletRigidbody.velocity = velocity;
            StartCoroutine(this.player.reload_bubble_charges(this.player.reload_time));
        }
    }
}
