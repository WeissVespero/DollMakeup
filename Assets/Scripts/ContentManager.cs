using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    [SerializeField] private ContentData _contentData;
    private Content _currentContent;
    private GameObject _content;

    public void ChangeContent(ContentType type)
    {
        if (_currentContent != null && _currentContent.ContentType == type) return;
        if(_currentContent!=null) Destroy(_content);
        _currentContent = _contentData.Contents.Find(p => p.ContentType == type);
        _content = Instantiate(_currentContent.ContentPrefab, transform);
        //var _contentData._contents
        print($"loading {type} content");
    }
}
