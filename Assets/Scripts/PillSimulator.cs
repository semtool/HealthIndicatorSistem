using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillSimulator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _pill;

    public event Action AmountChanged;

    public float Pill { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakePill);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakePill);
    }

    public void TakePill()
    {
        AmountChanged?.Invoke();
        Pill = _pill;
    }
}