using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private PillSimulator _pillSimulator;
    [SerializeField] private DamageSimulator _damageSimulator;

    public event Action CurrentHealthChanged;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = _maxHealth;
        CurrentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        _pillSimulator.HealthChanged += IncreaseHealth;
        _damageSimulator.HealthChanged += DecreaseHealth;
    }

    private void OnDisable()
    {
        _pillSimulator.HealthChanged -= IncreaseHealth;
        _damageSimulator.HealthChanged -= DecreaseHealth;
    }

    private void IncreaseHealth()
    {
        CurrentHealth += _pillSimulator.PieceOfHealth;

        if (CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }

        InformHealthIsChanged();
    }

    private void DecreaseHealth()
    {
        CurrentHealth -= _damageSimulator.PieceOfHealth;

        if (CurrentHealth < _minHealth)
        {
            CurrentHealth = _minHealth;
        }

        InformHealthIsChanged();
    }

    private void InformHealthIsChanged()
    {
        CurrentHealthChanged?.Invoke();
    }
}