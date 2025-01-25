using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunMovement : MonoBehaviour
{
    /* public fields */
    [SerializeField]
    public GameObject bullet_prefab;
    /* private fields */
    private PlayerMovement player;
    private Quaternion current_direction;
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
        if (player.current_direction == "Right")
        {
            transform.localPosition = new Vector2(7, 0);
            current_direction = Quaternion.Euler(0, 0, 0);
        }
        if (player.current_direction == "Left")
        {
            transform.localPosition = new Vector2(-7, 0);
            current_direction = Quaternion.Euler(0, 180, 0);
        }
        if (player.current_direction == "Up")
        {
            transform.localPosition = new Vector2(0, 7);
            current_direction = Quaternion.Euler(0, 0, 90);
        }
        if (player.current_direction == "Down")
        {
            transform.localPosition = new Vector2(0, -7);
            current_direction = Quaternion.Euler(0, 0, -90);
        }
    }
    /* Function that hanlde the Unity event that read the Shoot action */
    public void capture_shooting(InputAction.CallbackContext context)
    {
        Debug.Log("Fire button was pressed!");
        if (context.performed)
        {
            Instantiate(this.bullet_prefab, transform.position, this.current_direction);
        }
    }
}
