using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField] private GameplayInputManager _inputManager;

    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float _sensitivity = 15f;
    [SerializeField] private float _minVerticalAngle = -30f;
    [SerializeField] private float _maxVerticalAngle = 30f;

    private float _horizontal = 0f;
    private float _vertical = 0f;

    private void Start()
    {
        _inputManager.RotationInputReceivedInRotationZone += OnRotationInputReceived;
    }

    private void OnDestroy()
    {
        _inputManager.RotationInputReceivedInRotationZone -= OnRotationInputReceived;
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        _vertical -= _sensitivity * delta.y * Time.deltaTime;
        _horizontal += _sensitivity * delta.x * Time.deltaTime;

        _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);
        _rotationPoint.eulerAngles = new Vector3(_vertical, _horizontal, 0f);
    }
}
