using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPoint;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) || collision.gameObject.TryGetComponent(out EnemyBullet bullet))
        {
            collision.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);

        DisableObjectAbroadScreen();
    }

    private void DisableObjectAbroadScreen()
    {
        if (_camera.WorldToViewportPoint(transform.position).x > 1)
            gameObject.SetActive(false);
    }

    internal void PlaceInStartPoint()
    {
        transform.localPosition = _startPoint.position;
        transform.localRotation = _startPoint.rotation;
    }
}
