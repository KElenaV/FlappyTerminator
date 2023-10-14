using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _direction;
    [SerializeField] private float _delay = 0.6f;
    [SerializeField] private Transform _startPosition;

    private WaitForSeconds _waitForSecond;

    private void Awake()
    {
        _waitForSecond = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        StartCoroutine(Instantiate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground) == false)
        {
            collision.gameObject.SetActive(false);
        }
            
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    private IEnumerator Instantiate()
    {
        transform.localPosition = _startPosition.position;
        transform.localRotation = _startPosition.rotation;
        
        while (gameObject.activeSelf == true)
        {
            yield return _waitForSecond;
            gameObject.SetActive(false);
        }
    }

    internal void Init(Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
    }
}
