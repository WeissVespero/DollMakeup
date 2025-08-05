using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private Tool _creamTool;
    [SerializeField] private Hand _hand;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _creamTool.ToolClicked += HandGoToTool;
    }

    private void HandGoToTool(ToolSettings toolSettings)
    {
        _hand.RealPosition.position = toolSettings.RectTransform.position;
        _hand.BeginAction();
        _hand.SetCurrentToolSettings(toolSettings);
    }
}
