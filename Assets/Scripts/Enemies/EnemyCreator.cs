using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : Pool
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float delay = 5f;

    private WaitForSeconds _waitForSeconds;

    private void Start()
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
                int nextPoint = Random.Range(0, _points.Length);
                enemy.SetActive(true);
                enemy.transform.position = _points[nextPoint].position;
                enemy.transform.SetParent(_points[nextPoint]);
            }

            yield return _waitForSeconds;
        }
    }
}
