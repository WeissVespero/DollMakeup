using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropTool : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas _canvas;
    private Vector3 _originalPosition;
    private Vector3 _dragShift = new Vector3(-10,10,0);

    private void Awake()
    {
        _originalPosition = _rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Store the initial position
        _originalPosition = _rectTransform.anchoredPosition;

        // Make the item semi-transparent and disable raycasting
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the item with the mouse cursor
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        // Reset to original position
        _rectTransform.anchoredPosition = _originalPosition;
    }
}
