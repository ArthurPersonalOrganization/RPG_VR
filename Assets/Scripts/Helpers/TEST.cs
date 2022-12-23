using Scripts.Statistics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TEST : MonoBehaviour
{
    public StatsUI statsUI;
    public float playerSpeed = 5f;
    PlayerInput playerInput;
    InputAction moveAction;
    CharacterController Controller;
    private void Awake()
    {
        playerInput = GetComponent < PlayerInput >();
        moveAction = playerInput.actions["Move"];
        Controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    public void ReadACollectionTest()
    {
        List<string> names = new List<string>() { "rose", "beth", "jimbo" };

        var readOnly = new ReadOnlyCollection<string>(names);

        foreach (var readnames in readOnly)
        {
            Debug.Log(readnames);
        }
    }

    private void Update()
    {
        SimplestMovementOfPlayer();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //statsUI.CallRefresh();
        }
    }

    private void SimplestMovementOfPlayer()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        Controller.Move(move * Time.deltaTime * playerSpeed);
    }
}