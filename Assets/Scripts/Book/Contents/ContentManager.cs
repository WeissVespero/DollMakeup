using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ContentManager : MonoBehaviour
{
    [SerializeField] private ContentData _contentData;
    public Content CurrentContent;
    private Dictionary<ContentType, Content> _contentDictionary;

    private void Start()
    {
        _contentDictionary = _contentData.Contents.ToDictionary(x => x.ContentType, x => x);
    }

    public void ChangeContent(ContentType type)
    {
        if (CurrentContent != null && CurrentContent.ContentType == type) return;
        if (CurrentContent != null) Destroy(CurrentContent.gameObject);
        if (_contentDictionary.TryGetValue(type, out var contentPrefab))
        {
            CurrentContent = Instantiate(contentPrefab, transform);
        }
    }
}
