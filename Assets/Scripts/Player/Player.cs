using UnityEngine;

[RequireComponent(typeof(PlayerAction))]
public class Player : MonoBehaviour
{
    private PlayerAction _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<PlayerAction>();
    }

    public void Reset()
    {
        _score = 0;
        _mover.Reset();
    }

    public void Die()
    {
        Debug.Log("Died");
        Time.timeScale = 0;
    }
}
