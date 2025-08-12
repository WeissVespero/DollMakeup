using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public Transform RealPosition;
    public Vector3 StartToolPosition;
    private ToolSettings _currentToolSettings;

    public ToolSettings CurrentToolSettings => _currentToolSettings;

    public event Action<ToolType, int> ActionFinished;

    private void Start()
    {
        RealPosition = transform.parent;
    }

    public void BeginAction()
    {
        _animator.SetBool("IsToolClicked", true);
    }



    public void SetCurrentToolSettings(ToolSettings toolSettings)
    {
        _currentToolSettings = toolSettings;
        StartToolPosition = _currentToolSettings.RectTransform.position;
    }

    private void HandTakeTool()
    {
        _currentToolSettings.RectTransform.SetParent(transform);
    }

    private void ToolReturn()
    {
        _currentToolSettings.RectTransform.SetParent(_currentToolSettings.OriginalParentTransform);
        _currentToolSettings.RectTransform.position  = StartToolPosition;
        _animator.SetBool("IsActionBegin", false);
        ActionFinished.Invoke(_currentToolSettings.ToolType,_currentToolSettings.ID);
    }

    public void HandPerfomAction()
    {
        _animator.SetBool("IsToolClicked", false);
        _animator.SetBool("IsActionBegin", true);
    }
}
