using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pool _pool;
    [SerializeField] private Screen _startScreen;
    [SerializeField] private Screen _restartScreen;
    [SerializeField] private PlayerTracker _playerTracker;

    private void OnEnable()
    {
        _startScreen.ButtonClick += OnStartButtonClick;
        _restartScreen.ButtonClick += OnRestartButtonClick;
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _startScreen.ButtonClick -= OnStartButtonClick;
        _restartScreen.ButtonClick -= OnRestartButtonClick;
        _player.Died -= OnPlayerDied;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _playerTracker.enabled = false;
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0;
        _restartScreen.Open();
        _playerTracker.enabled = false;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _restartScreen.Close();
        _pool.Reset();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _playerTracker.enabled = true;
    }
}
