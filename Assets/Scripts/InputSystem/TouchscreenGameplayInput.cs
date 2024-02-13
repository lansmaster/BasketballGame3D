using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchscreenGameplayInput
{
    public event Action<Vector2> RotationInputReceivedInRotationZone;
    public event Action<Vector2> RotationInputReceivedInTrowingZone;

    private readonly InputMap _inputMap;
    private readonly RectTransform _inputRotationZone;
    private readonly RectTransform _inputTrowingZone;

    public TouchscreenGameplayInput(InputMap inputMap, RectTransform inputRotationZone, RectTransform inputTrowingZone)
    {
        _inputMap = inputMap;
        _inputRotationZone = inputRotationZone;
        _inputTrowingZone = inputTrowingZone;

        _inputMap.Touchscreen.TouchPress.started += OnTouchPressStarted;
        _inputMap.Touchscreen.TouchPress.canceled += OnTouchPressCanceled;
    }
    
    private void OnTouchPressStarted(InputAction.CallbackContext context)
    {
        var currentTouchPosition = _inputMap.Touchscreen.TouchPosition.ReadValue<Vector2>();
        var isTouchInRotationZone = RectTransformUtility.RectangleContainsScreenPoint(_inputRotationZone, currentTouchPosition);
        var isTouchInTrowingZone = RectTransformUtility.RectangleContainsScreenPoint(_inputTrowingZone, currentTouchPosition);

        if (isTouchInRotationZone)
        {
            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPerformedInRotationZone;
        }

        if(isTouchInTrowingZone)
        {
            _inputMap.Touchscreen.TouchDelta.performed += OnTouchDeltaPerformedInTrowingZone;
        }
    }

    private void OnTouchPressCanceled(InputAction.CallbackContext context)
    {
        _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPerformedInRotationZone;
        _inputMap.Touchscreen.TouchDelta.performed -= OnTouchDeltaPerformedInTrowingZone;
    }


    private void OnTouchDeltaPerformedInRotationZone(InputAction.CallbackContext context)
    {
        RotationInputReceivedInRotationZone?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnTouchDeltaPerformedInTrowingZone(InputAction.CallbackContext context)
    {
        RotationInputReceivedInTrowingZone?.Invoke(context.ReadValue<Vector2>());
    }
}
