using System;
using UnityEngine;
using UnityEngine.UI;

public  abstract class Simulator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _pieceOfHealth;

    public event Action HealthChanged;

    public float PieceOfHealth { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetPieceOfHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetPieceOfHealth);
    }

    public void SetPieceOfHealth()
    {
        PieceOfHealth  = _pieceOfHealth;

        HealthChanged?.Invoke();
    }
}