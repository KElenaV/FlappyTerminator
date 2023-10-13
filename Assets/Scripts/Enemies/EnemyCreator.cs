using System.Collections;
using UnityEngine;

public class EnemyCreator : Pool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float delay = 5f;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(delay);

        Initialize(_prefabs);

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (true)
        {
            if (TryGetObject(out GameObject enemy))
            {
                float nextPointY = Random.Range(_minPositionY, _maxPositionY);
                enemy.SetActive(true);
                enemy.transform.position = new Vector3(transform.position.x, nextPointY, transform.position.z);
                enemy.transform.SetParent(this.transform);

                DetermineAbroadPoint();
            }

            yield return _waitForSeconds;
        }
    }
}
