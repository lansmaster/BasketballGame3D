using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _rotaionPoint;

    private Rigidbody _rigidbody;

    public float moveSpeed;
    public float jumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3 (0f, _rotaionPoint.eulerAngles.y, 0f);

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate (movement * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetAxis("Jump") > 0)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}