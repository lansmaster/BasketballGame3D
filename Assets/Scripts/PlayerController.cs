using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public float moveSpeed = 1f;
    public float rotationSpeed = 3f;

    private void FixedUpdate()
    {


        float currentSpeed = moveSpeed * Input.GetAxis("Vertical");

        _characterController.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
