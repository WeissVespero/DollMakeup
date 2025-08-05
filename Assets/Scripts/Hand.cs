using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public Transform RealPosition;
    private ToolSettings _currentToolSettings;

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
    }

    private void HandTakeTool()
    {
        _currentToolSettings.RectTransform.SetParent(transform);
    }
}
