using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GunMovement : MonoBehaviour
{
    /* public fields */
    [SerializeField]
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
            transform.localPosition = new Vector2(1, 0);
            this.current_direction = Quaternion.Euler(0, 0, 0);
        }
        if (player.current_direction_string == "Left")
        {
            transform.localPosition = new Vector2(-1, 0);
            this.current_direction = Quaternion.Euler(0, 180, 0);
        }
        if (player.current_direction_string == "Up")
        {
            transform.localPosition = new Vector2(0, 1);
            this.current_direction = Quaternion.Euler(0, 0, 90);
        }
        if (player.current_direction_string == "Down")
        {
            transform.localPosition = new Vector2(0, -1);
            this.current_direction = Quaternion.Euler(0, 0, -90);
        }
    }
    /* Function that hanlde the Unity event that read the Shoot action */
    public void capture_shooting(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            GameObject bullet = Instantiate(this.bullet_prefab, transform);
        }
    }
}
