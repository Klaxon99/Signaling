using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Input.GetAxis(Vertical) * _movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * Input.GetAxis(Horizontal) * Time.deltaTime * _rotationSpeed);
    }
}
