using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 first_player_movement;
    public static Vector2 second_player_movement;


    private PlayerInput first_player_input;
    private PlayerInput second_player_input;

    private InputAction first_player_move;
    private InputAction second_player_move;

    private void Awake()
    {
        first_player_input = GetComponent<PlayerInput>();
        second_player_input= GetComponent<PlayerInput>();

        first_player_move = first_player_input.actions["Move"];
        second_player_move = second_player_input.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        first_player_movement = first_player_move.ReadValue<Vector2>();
        second_player_movement = second_player_move.ReadValue<Vector2>();
    }
}
