using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    [SerializeField] private Button _button;
    public ContentType TabType;
    public event Action<ContentType> OnTabClick;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _passiveImage;
    [SerializeField] private Sprite _activeImage;
    public bool IsActive = false;

    private void Start()
    {
        Subscribe();
        _image.sprite = _passiveImage;
    }

    private void Subscribe()
    {
        _button.onClick.AddListener(ClickAct);
    }
    
    private void ClickAct()
    {
        if (IsActive) return;
        IsActive = true;
        _image.sprite = _activeImage;
        OnTabClick?.Invoke(TabType);
    }

    public void SetNotActive()
    {
        IsActive = false;
        _image.sprite = _passiveImage;
    }
}

