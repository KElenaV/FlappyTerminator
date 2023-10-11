using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
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
