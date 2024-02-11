using System;
using UnityEngine;

public class GameplayInputManager : MonoBehaviour
{
    public event Action<Vector2> RotationInputReceived;

    private InputMap _inputMap;
    private MouseGameplayInput _mouseInput;

    private void Awake()
    {
        _inputMap = new InputMap();

        _inputMap.Enable();

        InitMouseInput(_inputMap);
    }

    private void InitMouseInput(InputMap inputMap)
    {
        _mouseInput = new MouseGameplayInput(inputMap);

        _mouseInput.RotationInputReceived += OnRotationInputReceived;
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        RotationInputReceived?.Invoke(delta);
    }
}
