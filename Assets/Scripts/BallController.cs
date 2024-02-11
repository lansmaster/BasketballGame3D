using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _ballDistanceOffset;
    [SerializeField] private float _ballThrowingForce;

    private Rigidbody _ballRigidbody;
    private bool _holdingBall = true;

    private void Start()
    {
        _ballRigidbody = _ball.GetComponent<Rigidbody>();
        _ballRigidbody.useGravity = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _holdingBall = true;
            _ballRigidbody.isKinematic = true;
        }

        if (_holdingBall)
        {
            _ballRigidbody.isKinematic = false;
            _ballRigidbody.useGravity = false;
            _ball.transform.position = _cameraTransform.position + _cameraTransform.forward * _ballDistanceOffset;

            if (Input.GetMouseButtonDown(0))
            {
                _holdingBall = false;
                _ballRigidbody.useGravity = true;
                _ballRigidbody.AddForce(_cameraTransform.forward * _ballThrowingForce);
            }
        }
    }
}
