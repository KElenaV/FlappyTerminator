using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.Self);

        if (_bullet.gameObject.activeSelf == false)
            _bullet.gameObject.SetActive(true);
    }
}
