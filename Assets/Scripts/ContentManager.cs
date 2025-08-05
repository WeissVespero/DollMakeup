using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ContentManager : MonoBehaviour
{
    [SerializeField] private ContentData _contentData;
    private Content _currentContent;
    private Dictionary<ContentType, Content> _contentDictionary;

    private void Start()
    {
        _contentDictionary = _contentData.Contents.ToDictionary(x => x.ContentType, x => x);
    }

    public void ChangeContent(ContentType type)
    {
        if (_currentContent != null && _currentContent.ContentType == type) return;
        if (_currentContent != null) Destroy(_currentContent.gameObject);
        if (_contentDictionary.TryGetValue(type, out var contentPrefab))
        {
            _currentContent = Instantiate(contentPrefab, transform);
        }
    }
}
