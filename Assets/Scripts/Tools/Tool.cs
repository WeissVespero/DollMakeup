using System;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Color _toolColor;
    [SerializeField] private ToolType _toolType;
    [SerializeField] private ApplicatorBase _applicator;
    public int ToolID;

    public event Action<ToolSettings> ToolClicked;

    private bool _isHeld;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _button.onClick.AddListener(ClickAct);
    }

    private void ClickAct()
    {
        if (_isHeld) return;
        _isHeld = true;

        var rectTransform = _applicator.transform as RectTransform;

        ToolClicked?.Invoke(new ToolSettings
        {
            ToolType = _toolType,
            Color = _toolColor,
            RectTransform = rectTransform,
            OriginalParentTransform = rectTransform.parent,
            ID = ToolID
        });
        _applicator.OnActivated(_toolColor);
    }

    public void SetIsHeldFalse()
    {
        _isHeld = false;
    }

    private void Unsubscribe()
    {
        _button.onClick.RemoveAllListeners();
    }
}
