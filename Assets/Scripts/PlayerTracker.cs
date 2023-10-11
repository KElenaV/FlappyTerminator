using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        Vector3 position = transform.position;

        transform.position = new Vector3(_target.transform.position.x + _offsetX, position.y, position.z);
    }
}
