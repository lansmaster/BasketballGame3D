using System;
using UnityEngine;

public class GameplayInputManager : MonoBehaviour
{
    [SerializeField] private RectTransform _rotationInputZone;
    [SerializeField] private RectTransform _rotationTrowingZone;

    public event Action<Vector2> RotationInputReceivedInRotationZone;
    public event Action<Vector2> RotationInputReceivedInTrowingZone;

    private InputMap _inputMap;
    private TouchscreenGameplayInput _touchscreenInput;
    //private MouseGameplayInput _mouseInput;

    private void Awake()
    {
        _inputMap = new InputMap();

        _inputMap.Enable();

        InitTouchscreenInput(_inputMap);
        //InitMouseInput(_inputMap);
    }

    private void InitTouchscreenInput(InputMap inputMap)
    {
        _touchscreenInput = new TouchscreenGameplayInput(inputMap, _rotationInputZone, _rotationTrowingZone);

        _touchscreenInput.RotationInputReceivedInRotationZone += OnRotationInputReceivedInRotationZone;
        _touchscreenInput.RotationInputReceivedInTrowingZone += OnRotationInputReceivedInTrowingZone;
    }

    //private void InitMouseInput(InputMap inputMap)
    //{
    //    _mouseInput = new MouseGameplayInput(inputMap);

    //    _mouseInput.RotationInputReceived += RotationInputReceivedInRotationZone;
    //}

    private void OnRotationInputReceivedInRotationZone(Vector2 delta)
    {
        RotationInputReceivedInRotationZone?.Invoke(delta);
    }

    private void OnRotationInputReceivedInTrowingZone(Vector2 delta)
    {
        RotationInputReceivedInTrowingZone?.Invoke(delta);
    }
}
