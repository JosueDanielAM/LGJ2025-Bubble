using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /* public fields */
    [SerializeField]
    public float speed;
    public string current_direction;
    public bool idle;
    /* private fields */
    private Vector2 movement;
    private PlayerInput player_input;
    private Rigidbody2D physics;

    /* Unity functions */
    private void Awake()
    {
        this.physics = GetComponent<Rigidbody2D>();
        this.player_input = GetComponent<PlayerInput>();
    }
    void Update()
    {
        this.move();
    }
    
    /* Las buenas practicas */
    private void OnEnable()
    {
        if (player_input != null)
        {
            player_input.actions["Move"].performed += capture_movement;
        }
    }

    /* Las buenas practicas */
    private void OnDisable()
    {
        if (player_input != null)
        {
            player_input.actions["Move"].performed -= capture_movement;
        }
    }

    /* Function that handle the Unity event that reads the Move action */
    public void capture_movement(InputAction.CallbackContext context)
    {
        this.movement = context.ReadValue<Vector2>();
    }
    /* Function that moves the player */
    private void move()
    {
        this.physics.velocity = this.movement * this.speed;

        if (this.movement.x == 0 && this.movement.y == 0)
        {
            this.idle = true;
        }
        else
        {
            float x_abs, y_abs;

            x_abs = Mathf.Abs(this.movement.x);
            y_abs = Mathf.Abs(this.movement.y);
            this.idle = false;

            if (x_abs < y_abs)
            {
                if (this.movement.y > 0)
                {
                    this.current_direction = "Up";
                }
                else
                {
                    this.current_direction = "Down";
                }

            }
            //si se remplaza esta selectiva por un else 
            //se obtiene el movimiento el juego de los helados
            if (x_abs > y_abs)
            {
                if (this.movement.x > 0)
                {
                    this.current_direction = "Right";
                }
                else
                {
                    this.current_direction = "Left";
                }
            }
        }
    }
}
