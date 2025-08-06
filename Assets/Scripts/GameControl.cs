using System.Collections;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private Tool _creamTool;
    [SerializeField] private Hand _hand;
    [SerializeField] private DropZone _dropZone;
    [SerializeField] private GameObject _acne;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _creamTool.ToolClicked += HandGoToTool;
        _dropZone.ToolDropped += ToolAction;
    }

    private void HandGoToTool(ToolSettings toolSettings)
    {
        _hand.RealPosition.position = toolSettings.RectTransform.position;
        _hand.BeginAction();
        _hand.SetCurrentToolSettings(toolSettings);
    }

    private void ToolAction()
    {
        _hand.HandPerfomAction();
        _creamTool.SetIsHeldFalse();
        StartCoroutine(ClearFace());
    }

    private IEnumerator ClearFace()
    {
        yield return new WaitForSeconds(1);
        _acne.SetActive(false);
    }
}
