using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    /* public fields */
    [SerializeField]
    public float speed;
    [SerializeField]
    public int max_number_destructible_walls = 3;
    public string current_direction_string;
    public Quaternion current_direction;
    public bool idle;
    public GameObject destructible_wall_prefab;
    /* private fields */
    private Vector2 movement;
    private PlayerInput player_input;
    private Rigidbody2D physics;
    private Coroutine[] destructible_walls = new Coroutine[50];
    private bool[] is_destructible_wall_created = new bool[50];
    private bool is_puttin_wall_pressed = false;
    private int score = 0;

    /* Unity functions */
    private void Awake()
    {
        this.physics = GetComponent<Rigidbody2D>();
        this.player_input = GetComponent<PlayerInput>();
    }
    void Update()
    {
        if (!this.is_puttin_wall_pressed)
        {
            this.move();
        }
        else
        {
            this.movement = Vector2.zero;
            this.move();
        }
    }

    private void OnEnable()
    {
        if (player_input != null)
        {
            player_input.actions["Move"].performed += capture_movement;
        }
    }

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

    /* Function that handles the Unity event that reads the PutWall action */
    public void capture_putting_wall(InputAction.CallbackContext context)
    {
        float x_truc = Mathf.Round(transform.position.x);
        float y_truc = Mathf.Round(transform.position.y);

        if (context.started)
        {
            this.is_puttin_wall_pressed = true;

            for (int i = 0; i != this.max_number_destructible_walls; i++)
            {
                this.destructible_walls[i] = StartCoroutine(
                    create_destructible_wall(0.5f + 0.2f * i, i, x_truc, y_truc));
            }
        }

        if (context.canceled && is_puttin_wall_pressed)
        {
            this.is_puttin_wall_pressed = false;

            foreach (var destructible_wall in destructible_walls)
            {
                if (destructible_wall != null)
                {
                    StopCoroutine(destructible_wall);
                }
            }
        }
    }

    // Coroutine to track elapsed time for each action
    private IEnumerator create_destructible_wall(float duration, int index, float x_truc, float y_truc)
    {
        float start = Time.time;
        this.is_destructible_wall_created[index] = false;

        while (Time.time - start < duration)
        {
            yield return null;
        }

        if (Time.time - start > 0)
        {
            is_destructible_wall_created[index] = true;
        }

        if (this.current_direction_string == "Right")
        {
            GameObject destructible_wall = Instantiate(
                this.destructible_wall_prefab,
                new Vector2(x_truc + 2 + index, y_truc),
                this.current_direction);
        }
        if (this.current_direction_string == "Left")
        {
            GameObject destructible_wall = Instantiate(
                this.destructible_wall_prefab,
                new Vector2(x_truc - 2 - index, y_truc),
                this.current_direction);
        }
        if (this.current_direction_string == "Up")
        {
            GameObject destructible_wall = Instantiate(
                this.destructible_wall_prefab,
                new Vector2(x_truc, y_truc + 2 + index),
                this.current_direction);
        }
        if (this.current_direction_string == "Down")
        {
            GameObject destructible_wall = Instantiate(
                this.destructible_wall_prefab,
                new Vector2(x_truc, y_truc - 2 - index),
                this.current_direction);
        }
    }
    /* Function that moves the player */
    private void move()
    {
        this.physics.velocity = this.movement;

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
                    this.current_direction_string = "Up";
                    this.current_direction = Quaternion.Euler(0, 0, 90);

                }
                else
                {
                    this.current_direction_string = "Down";
                    this.current_direction = Quaternion.Euler(0, 0, -90);
                }

            }
            //si se remplaza esta selectiva por un else 
            //se obtiene el movimiento el juego de los helados
            if (x_abs > y_abs)
            {
                if (this.movement.x > 0)
                {
                    this.current_direction_string = "Right";
                    this.current_direction = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    this.current_direction_string = "Left";
                    this.current_direction = Quaternion.Euler(0, 180, 0);
                }
            }
        }
    }

    public void AddPoint()
    {
        this.score++;
        Debug.Log($"Player {GetComponent<PlayerInput>().playerIndex} scored! Total points: {score}");
    }
}

