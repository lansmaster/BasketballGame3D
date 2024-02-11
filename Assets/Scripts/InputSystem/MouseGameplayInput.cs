using System;
using UnityEngine;

public class MouseGameplayInput
{
    public event Action<Vector2> RotationInputReceived;

    public MouseGameplayInput(InputMap inputMap)
    {
        inputMap.KeyboardAndMouse.MouseDelta.performed += context =>
        {
            Vector2 mouseDelta = context.ReadValue<Vector2>();

            RotationInputReceived?.Invoke(mouseDelta);
        };
    }
}