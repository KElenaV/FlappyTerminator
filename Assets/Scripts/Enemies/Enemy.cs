using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyBullet _bullet;

    private float _delay = 1.5f;
    private float _elapsedTime;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (_bullet.gameObject.activeSelf == false)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _delay)
            {
                _elapsedTime = 0;
                _bullet.gameObject.SetActive(true);
            }
        }
    }
}
