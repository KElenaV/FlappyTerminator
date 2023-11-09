using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay = 0.6f;
    [SerializeField] private Enemy _enemy;

    private Vector3 _startPoint;

    private WaitForSeconds _waitForSecond;

    private void Awake()
    {
        _waitForSecond = new WaitForSeconds(_delay);
        _startPoint = transform.localPosition;
    }

    private void OnEnable()
    {
        StartCoroutine(Instantiate());
        gameObject.transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private IEnumerator Instantiate()
    {
        transform.localPosition = _startPoint;

        yield return _waitForSecond;
        gameObject.transform.parent = _enemy.transform;
        gameObject.SetActive(false);
    }
}
