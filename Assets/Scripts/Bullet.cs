using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _direction;
    [SerializeField] private float _delay = 2;

    private Vector3 _startPosition;
    private Transform _player;
    private WaitForSeconds _waitForSecond;

    private void Awake()
    {
        _startPosition = transform.localPosition;
        _waitForSecond = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        StartCoroutine(Instantiate());
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private IEnumerator Instantiate()
    {
        yield return _waitForSecond;

        transform.localPosition = _startPosition;
        gameObject.SetActive(false);
    }
}
