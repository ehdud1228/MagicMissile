using System;
using System.Collections;
using System.Collections.Generic;
using Pawn;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Pawns.Pawn
{
    // Singleton
    private static PlayerController instance = null;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnMove(InputValue inputValue)
    {
        var moveDir = inputValue.Get<Vector2>();
        Move(moveDir);
    }
}
