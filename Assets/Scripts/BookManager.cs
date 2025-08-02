using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private TabManager _tabManager;
    [SerializeField] private ContentManager _contentManager;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _tabManager.OnTabChange += ChangeContent;
    }

    private void ChangeContent(ContentType type)
    {
        _contentManager.ChangeContent(type);
    }
}
