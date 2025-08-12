using UnityEngine;
using UnityEngine.UI;

internal class ApplicatorEyeBrush : ApplicatorBase
{
    [SerializeField] private Image _eyeBrushTopImage;

    public override void OnActivated(Color color)
    {
        _eyeBrushTopImage.color = color;
    }
}
