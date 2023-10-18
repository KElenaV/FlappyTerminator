using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAction))]
public class Player : MonoBehaviour
{
    private PlayerBullet _bullet;

    private PlayerAction _playerAction;
    private int _score;

    public event UnityAction Died;

    private void Start()
    {
        _playerAction = GetComponent<PlayerAction>();
    }

    public void ScoreChanged()
    {
        _score++;
    }

    public void Reset()
    {
        _score = 0;
        _playerAction.Reset();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
