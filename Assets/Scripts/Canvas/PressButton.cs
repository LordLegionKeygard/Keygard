using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPressed = false;
    public UnityEvent OnPressed;

    private void Update()
    {
        if (_isPressed == true)
        {
            OnPressed.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
}
