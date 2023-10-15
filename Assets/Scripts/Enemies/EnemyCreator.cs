using System.Collections;
using UnityEngine;

public class EnemyCreator : Pool
{
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
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
                float nextPositionY = Random.Range(_minPositionY, _maxPositionY);
                enemy.transform.position = new Vector2(transform.position.x, nextPositionY);
                enemy.transform.SetParent(this.transform);
                enemy.SetActive(true);

                DisableObjectAbroadScreen();
            }

            yield return _waitForSeconds;
        }
    }
}
