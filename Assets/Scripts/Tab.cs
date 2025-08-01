using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ContentType _tabType;
    public event Action<ContentType> SomeAction;

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
        SomeAction.Invoke(_tabType);
    }
}

public enum ContentType
{
    Blush,
    Eyeshadow,
    Lipstick,
    Powder
}
