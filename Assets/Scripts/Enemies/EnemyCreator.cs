using System.Collections;
using UnityEngine;

public class EnemyCreator : Pool
{
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private GameObject[] _template;
    [SerializeField] private float delay = 5f;

    private WaitForSeconds _waitForSeconds;
    private Enemy _enemy;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(delay);

        Initialize(_template);

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (true)
        {
            if (TryGetObject(out GameObject _enemy))
            {
                float nextPositionY = Random.Range(_minPositionY, _maxPositionY);
                _enemy.transform.position = new Vector2(transform.position.x, nextPositionY);
                _enemy.transform.SetParent(this.transform);
                _enemy.SetActive(true);

                DisableObjectAbroadScreen();
            }

            yield return _waitForSeconds;
        }
    }

    public void Reset()
    {
        _enemy.gameObject.SetActive(false);
        _enemy.Bullet.gameObject.SetActive(false);
    }
}
