using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthScale : MonoBehaviour
{
    [SerializeField] public Slider _barScale;
    [SerializeField] public Health _health;

    private float _barVolueMultiplier = 0.01f;

    private void Start()
    {
        _barScale.value = GetCurrentBarVolue();
    }

    private void OnEnable()
    {
        _health.CurrentHealthChanged += ChangeBarView;
    }

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= ChangeBarView;
    }

    public abstract void ChangeBarView();

    public float GetCurrentBarVolue()
    {
        return _health.CurrentHealth * _barVolueMultiplier;
    }
}