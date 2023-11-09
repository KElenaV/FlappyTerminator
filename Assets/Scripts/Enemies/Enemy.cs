using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyBullet _bullet;

    private float _delay = 1.5f;

    public EnemyBullet Bullet => _bullet;

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

   private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Debug.Log(_delay);

            if (_bullet.gameObject.activeSelf == false)
                _bullet.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        _bullet.gameObject.SetActive(false);
    }
}
