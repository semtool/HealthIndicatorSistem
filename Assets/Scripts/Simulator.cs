using System;
using UnityEngine;
using UnityEngine.UI;

public  abstract class Simulator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _pieceOfHealth;

    public event Action HealthChanged;

    public float PieceOfHealth { get; private set; }

    private void Awake()
    {
        PieceOfHealth = _pieceOfHealth;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UsePieceOfHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UsePieceOfHealth);
    }

    private void UsePieceOfHealth()
    {
        HealthChanged?.Invoke();
    }
}