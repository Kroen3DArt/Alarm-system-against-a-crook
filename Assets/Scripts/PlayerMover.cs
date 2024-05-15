using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotateSpeed = 120f;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        Vector3 rotationVector = rotation * _rotateSpeed * Time.deltaTime * Vector3.up;
        Quaternion quaternion = Quaternion.Euler(rotationVector);
        _rigidbody.MoveRotation(_rigidbody.rotation * quaternion);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);

        Vector3 movement = _moveSpeed * direction * Time.fixedDeltaTime * transform.forward;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }
}
