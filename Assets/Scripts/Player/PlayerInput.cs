using UnityEngine;

[RequireComponent(typeof(PlayerAction))]
public class PlayerInput : MonoBehaviour
{
    private PlayerAction _action;

    private void Awake()
    {
        _action = GetComponent<PlayerAction>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _action.AllowJump();

        if (Input.GetMouseButtonDown(0))
            _action.TryShoot();
    }
}
