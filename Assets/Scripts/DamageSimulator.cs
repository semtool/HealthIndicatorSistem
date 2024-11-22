using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSimulator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _damage;

    public event Action AmountChanged;

    public float Damage { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeDamage);
    }

    public void TakeDamage()
    {
        AmountChanged?.Invoke();
        Damage = _damage;
    }
}
