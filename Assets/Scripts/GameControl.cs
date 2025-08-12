using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private Tool _creamTool;
    [SerializeField] private Loofah _loofah;
    [SerializeField] private Hand _hand;
    [SerializeField] private DropZone _dropZone;
    [SerializeField] private Girl _girl;
    [SerializeField] private BookManager _bookManager;
    private List<Tool> _subscribedTools = new List<Tool>();

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _loofah.LoofahClicked += CleanFace;
        _hand.ActionFinished += ChangeFace;
        _creamTool.ToolClicked += MoveToolToHand;
        _dropZone.ToolDropped += ToolAction;
        _bookManager.ContentChanged += SubscribeToBookTools;
    }

    private void Unsubscribe()
    {
        _hand.ActionFinished -= ChangeFace;
        _creamTool.ToolClicked -= MoveToolToHand;
        _dropZone.ToolDropped -= ToolAction;
        _bookManager.ContentChanged -= SubscribeToBookTools;
    }

    private void MoveToolToHand(ToolSettings toolSettings)
    {
        _hand.RealPosition.position = toolSettings.RectTransform.position;
        _hand.BeginAction();
        _hand.SetCurrentToolSettings(toolSettings);
    }

    private void ToolAction()
    {
        print("ToolAction perfoms");
        _hand.HandPerfomAction();
        _creamTool.SetIsHeldFalse();
        if (_subscribedTools.Count != 0)
        {
            SetToolsIsHeldFalse();
        }
    }

    private void SetToolsIsHeldFalse()
    {
        for (int i = 0; i < _subscribedTools.Count; i++)
        {

            _subscribedTools[i].SetIsHeldFalse();
        }
    }

    private void ChangeFace(ToolType toolType, int toolID)
    {        
        _girl.MakeUp(toolType, toolID);
    }

    private void CleanFace()
    {
        _girl.ResetFace();
    }

    private void SubscribeToBookTools(Tool[] tools)
    {
        if (_subscribedTools.Count != 0)
        {
            UnsubscribeFromBookTools();
        }

        for (int i = 0; i < tools.Length; i++)
        {
            _subscribedTools.Add(tools[i]);
            _subscribedTools[i].ToolClicked += MoveToolToHand;
        }
    }

    private void UnsubscribeFromBookTools()
    {
        for (int i = _subscribedTools.Count -1; i >=0 ; i--)
        {
            _subscribedTools[i].ToolClicked -= MoveToolToHand;
            _subscribedTools.RemoveAt(i);
        }
    }

    private void OnToolClicked(ToolSettings obj)
    {
        print("tool clicked");
    }
}
