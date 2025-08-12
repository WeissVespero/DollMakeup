using System;
using UnityEngine.UI;
using UnityEngine;

public class Loofah : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event Action LoofahClicked;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _button.onClick.AddListener(() => LoofahClicked.Invoke());
    }
}
