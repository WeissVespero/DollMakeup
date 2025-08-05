using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeBrush : MonoBehaviour
{
    public Color[] colors;
    [SerializeField] private Image _brushTop;

    private void Start()
    {
        _brushTop.color = colors[1];
    }
}
