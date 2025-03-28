using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player Input Interface
/// </summary>
public interface IPlayerInput
{
    public Vector2 InputVec { get; }
    public bool MouseClick { get; }

    void OnMove(InputValue value);
    void OnFire(InputValue value);
}
