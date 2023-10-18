using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;

    public event UnityAction ButtonClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ButtonClick?.Invoke();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _button.interactable = true;
        _buttonImage.raycastTarget = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
        _buttonImage.raycastTarget = false;
    }
}
