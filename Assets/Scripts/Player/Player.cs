using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _bulletPoint;

    private PlayerMover _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet bullet = Instantiate(_bullet, _bulletPoint.position, transform.rotation, _container);
            bullet.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        _score = 0;
        _mover.Reset();
    }

    public void Die()
    {
        Time.timeScale = 0;
    }
}
