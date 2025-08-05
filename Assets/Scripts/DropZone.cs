using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public event Action ToolDropped;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped on the DropZone!");

        // Check if the dropped item has the DragAndDropItem script
        if (eventData.pointerDrag != null)
        {
            // Get the dragged item's script
            DragAndDropTool draggedItem = eventData.pointerDrag.GetComponent<DragAndDropTool>();

            // Reparent the dragged item to this drop zone
            //draggedItem.transform.SetParent(transform, false);
            ToolDropped.Invoke();
        }
    }
}
