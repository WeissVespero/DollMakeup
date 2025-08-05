using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    private ContentType _currentType;
    [SerializeField] private TabData _tabData;
    public List<Tab> _tabs = new List<Tab>();
    public event Action<ContentType> OnTabChange;

    private void Start()
    {
        InstantinateTabs();
    }

    private void InstantinateTabs()
    {
        foreach (var tab in _tabData._tabPrefabs)
        {
            var newTab = Instantiate(tab,transform);
            newTab.OnTabClick += SetCurrentType;
            _tabs.Add(newTab);
        }
    }

    private void Unsubscribe()
    {
        foreach (var tab in _tabs)
        {
            tab.OnTabClick -= SetCurrentType;
        }
    }

    private void SetCurrentType(ContentType type)
    {
        
        _currentType = type;
        foreach (var tab in _tabs)
        {
            if(tab.TabType != _currentType)
            {
                tab.SetNotActive();
            }
            
        }
        OnTabChange?.Invoke(_currentType);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
