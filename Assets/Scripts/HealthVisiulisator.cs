using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthVisiulisator : MonoBehaviour
{
    [SerializeField] private Button _pillButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Slider _healsBar;
    [SerializeField] private Slider _healsSmoothBar;

    private PillSimulator _pillSimulator;
    private DamageSimulator _damageSimulator;
    private Coroutine _coroutine;
    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _currentHealth = 100;

    private void Awake()
    {
        _pillSimulator = _pillButton.GetComponent<PillSimulator>();
        _damageSimulator = _damageButton.GetComponent<DamageSimulator>();
    }

    private void Start()
    {
        _healsBar.value = _currentHealth;
        _healsSmoothBar.value = _currentHealth;

        ShowHealthRatio();
    }

    private void OnEnable()
    {
        _pillSimulator.AmountChanged += IncreaseHealth;
        _damageSimulator.AmountChanged += DecreaseHealth;
    }

    private void OnDisable()
    {
        _pillSimulator.AmountChanged -= IncreaseHealth;
        _damageSimulator.AmountChanged -= DecreaseHealth;
    }

    private void IncreaseHealth()
    {
        _currentHealth += _pillSimulator.Pill;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        ShowHealthRatio();

        ChangeBarView();
    }

    private void DecreaseHealth()
    {
        _currentHealth -= _damageSimulator.Damage;

        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }

        ShowHealthRatio();

        ChangeBarView();
    }

    private void ShowHealthRatio()
    {
        _textMesh.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
    }

    private void ChangeBarView()
    {
        _healsBar.value = _currentHealth * 0.01f;

        ChangeSmoothBarView(_healsBar.value);
    }

    private void ChangeSmoothBarView(float target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Move(target));
    }

    private IEnumerator Move(float target)
    {
        while (_healsSmoothBar.value != target)
        {           
            _healsSmoothBar.value = Mathf.MoveTowards(_healsSmoothBar.value, target, 0.2f * Time.deltaTime);

            yield return null;
        }
    }
}
