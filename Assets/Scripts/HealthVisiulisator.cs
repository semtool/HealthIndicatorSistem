using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisiulisator : MonoBehaviour
{
    [SerializeField] private Button _pillButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _healthSmoothBar;

    private PillSimulator _pillSimulator;
    private DamageSimulator _damageSimulator;
    private HealthSmoothBar _smoothBar;
    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _currentHealth = 100;
    private float _volueMultiplier = 0.01f;

    private void Awake()
    {
        _pillSimulator = _pillButton.GetComponent<PillSimulator>();
        _damageSimulator = _damageButton.GetComponent<DamageSimulator>();
        _smoothBar = _healthSmoothBar.GetComponent<HealthSmoothBar>();
    }

    private void Start()
    {
        _healthBar.value = SetCurrentBarVolue();

        _healthSmoothBar.value = SetCurrentBarVolue();

        ShowHealthStatus();
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
        _currentHealth += _pillSimulator.PieceOfHealth;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        ShowHealthStatus();

        ChangeBarView();
    }

    private void DecreaseHealth()
    {
        _currentHealth -= _damageSimulator.PieceOfHealth;

        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }

        ShowHealthStatus();

        ChangeBarView();
    }

    private void ShowHealthStatus()
    {
        _textMesh.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
    }

    private void ChangeBarView()
    {
        _healthBar.value = SetCurrentBarVolue();

        _smoothBar.ChangeSmoothBarView(_healthBar.value);
    }

    private float SetCurrentBarVolue()
    {
        return _currentHealth * _volueMultiplier;
    }
}