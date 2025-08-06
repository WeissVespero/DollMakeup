using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Color _toolColor;
    [SerializeField] private ToolType _toolType;
    private bool _isHeld;

    public event Action<ToolSettings> ToolClicked;

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

        ToolClicked?.Invoke(new ToolSettings
        {
            ToolType = _toolType,
            Color = _toolColor,
            RectTransform = transform as RectTransform,
            OriginalParentTransform = transform.parent
        });
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
