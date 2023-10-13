using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] templates)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int index = Random.Range(0, templates.Length);
            GameObject spawned = Instantiate(templates[index], _container);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void DetermineAbroadPoint()
    {
        Vector3 abroadPoint = _camera.ViewportToWorldPoint(new Vector2(-0.1f, 0.5f));

        foreach (var item in _pool)
        {
            if ((item.activeSelf == true) && (item.transform.position.x < abroadPoint.x))
                item.SetActive(false);
        }
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
