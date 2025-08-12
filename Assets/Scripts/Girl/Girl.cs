using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public List<Lipstick> Lipsticks = new List<Lipstick>();
    public List<EyeShadow> EyeShadows = new List<EyeShadow>();
    [SerializeField] private GameObject _acne;

    public void MakeUp(ToolType toolType, int toolID)
    {
        switch (toolType)
        {
            case ToolType.Cream:
                _acne.SetActive(false);
                break;
            case ToolType.Lipstick:
                SetLips(toolID);
                break;
            case ToolType.Eyeshadow:
                SetEyes(toolID);
                break;
            default:
                break;
        }
    }
    private void SetLips(int toolID)
    {
        SetAllLipsNonActive();
        Lipsticks[toolID].gameObject.SetActive(true);
    }

    private void SetAllLipsNonActive()
    {
        foreach (var lips in Lipsticks)
        {
            lips.gameObject.SetActive(false);
        }
    }

    private void SetEyes(int toolID)
    {
        SetAllEyesNonActive();
        EyeShadows[toolID].gameObject.SetActive(true);
    }

    private void SetAllEyesNonActive()
    {
        foreach (var eyes in EyeShadows)
        {
            eyes.gameObject.SetActive(false);
        }
    }

    public void ResetFace()
    {
        SetAllEyesNonActive();
        SetAllLipsNonActive();
        _acne.SetActive(true);
    }
}
