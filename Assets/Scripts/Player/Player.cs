using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAction))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bullet;

    private PlayerAction _playerAction;
    private int _score;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _bullet.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _bullet.EnemyKilled -= OnEnemyKilled;
    }

    private void Start()
    {
        _playerAction = GetComponent<PlayerAction>();
    }

    private void OnEnemyKilled()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _playerAction.Reset();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
