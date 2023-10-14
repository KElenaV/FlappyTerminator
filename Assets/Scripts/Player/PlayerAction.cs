using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minAngleZ;
    [SerializeField] private float _maxAngleZ;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Bullet _bullet;

    private bool _canJump;
    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private Quaternion _minAngle;
    private Quaternion _maxAngle;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _minAngle = SetAngle(_minAngleZ);
        _maxAngle = SetAngle(_maxAngleZ);

        Reset();
    }

    private void Update()
    {
        TurnDown();
    }

    private void FixedUpdate()
    {
        if (_canJump)
            Jump();
    }

    public void AllowJump() => _canJump = true;

    public void TryShoot()
    {
        if (_bullet.gameObject.activeSelf == false)
            _bullet.gameObject.SetActive(true);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(Vector2.zero);
        _rigidbody.velocity = Vector2.zero;
    }

    private void TurnDown() =>
        transform.rotation = Quaternion.Lerp(transform.rotation, _minAngle, _rotationSpeed * Time.deltaTime);

    private Quaternion SetAngle(float angle) =>
        Quaternion.Euler(new Vector3(0, 0, angle));


    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
        transform.rotation = _maxAngle;
        _canJump = false;
    }
}
