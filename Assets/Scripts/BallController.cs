using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameplayInputManager _inputManager;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _ballDistanceOffset = 2f;
    [SerializeField] private float _ballThrowingForce = 0.4f;
    [SerializeField] private float _ballThrowingDistance = 0.5f;

    private Rigidbody _ballRigidbody;
    private bool _holdingBall = true;

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
        _ballRigidbody.useGravity = false;
        _inputManager.RotationInputReceivedInTrowingZone += OnRotationInputReceived;
    }

    private void OnDestroy()
    {
        _inputManager.RotationInputReceivedInTrowingZone -= OnRotationInputReceived;
    }

    private void Update()
    {
        Debug.Log(_cameraTransform.forward);

        if (_holdingBall)
        {
            _ballRigidbody.isKinematic = false;
            _ballRigidbody.useGravity = false;
            transform.position = _cameraTransform.position + _cameraTransform.forward * _ballDistanceOffset;
        }
    }

    public void PickUpBall() // кнопка
    {
        _holdingBall = true;
        _ballRigidbody.isKinematic = true;
        _inputManager.RotationInputReceivedInTrowingZone += OnRotationInputReceived;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Ground")
        {
            _holdingBall = true;
            _ballRigidbody.isKinematic = true;
            _inputManager.RotationInputReceivedInTrowingZone += OnRotationInputReceived;
        }
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        StartCoroutine(Wait());

        _holdingBall = false;
        _ballRigidbody.useGravity = true;

        if(_cameraTransform.forward.x < 0 && _cameraTransform.forward.z > 0) 
        {
            Debug.Log("Сектор 1");

            var throwingVector = new Vector3
            (
                _cameraTransform.forward.x * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * Mathf.Abs(_cameraTransform.forward.z)),
                (_cameraTransform.forward.y * delta.y) + delta.y,
                _cameraTransform.forward.z * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.z)))
            );
            _ballRigidbody.AddForce(throwingVector * _ballThrowingForce);
        }
        else if(_cameraTransform.forward.x > 0 && _cameraTransform.forward.z > 0)
        {

        }
        else if (_cameraTransform.forward.x > 0 && _cameraTransform.forward.z < 0)
        {

        }
        else if (_cameraTransform.forward.x < 0 && _cameraTransform.forward.z < 0)
        {

        }
        


        if (_cameraTransform.forward.x >= 0f && _cameraTransform.forward.x <= 1f && _cameraTransform.forward.z <= 1f && _cameraTransform.forward.z >= 0f)
        {
            Debug.Log("Сектор 2");

            var throwingVector = new Vector3
            (
                _cameraTransform.forward.x * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * Mathf.Abs(_cameraTransform.forward.z)),
                (_cameraTransform.forward.y * delta.y) + delta.y,
                _cameraTransform.forward.z * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.z)))
            );
            _ballRigidbody.AddForce(throwingVector * _ballThrowingForce);
        }
        if (_cameraTransform.forward.x >= 0f && _cameraTransform.forward.x <= 1f && _cameraTransform.forward.z <= 0f && _cameraTransform.forward.z >= -1f)
        {
            Debug.Log("Сектор 3");

            var throwingVector = new Vector3
            (
                _cameraTransform.forward.x * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.x))),
                (_cameraTransform.forward.y * delta.y) + delta.y,
                _cameraTransform.forward.z * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * _cameraTransform.forward.z)
            );
            _ballRigidbody.AddForce(throwingVector * _ballThrowingForce);
        }
        if (_cameraTransform.forward.x >= -1f && _cameraTransform.forward.x <= 0f && _cameraTransform.forward.z <= 0f && _cameraTransform.forward.z >= -1f)
        {
            Debug.Log("Сектор 4");

            var throwingVector = new Vector3
            (
                _cameraTransform.forward.x * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * _cameraTransform.forward.x),
                (_cameraTransform.forward.y * delta.y) + delta.y,
                _cameraTransform.forward.z * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.z)))
            );
            _ballRigidbody.AddForce(throwingVector * _ballThrowingForce);
        }
        else
        {
            var throwingVector = new Vector3
            (
                _cameraTransform.forward.x * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.x))),
                (_cameraTransform.forward.y * delta.y) + delta.y,
                _cameraTransform.forward.z * Mathf.Abs(delta.y) * _ballThrowingDistance + (delta.x * (1 - Mathf.Abs(_cameraTransform.forward.z)))
            );
            _ballRigidbody.AddForce(throwingVector * _ballThrowingForce);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        _inputManager.RotationInputReceivedInTrowingZone -= OnRotationInputReceived;
    }
}
