using TMPro;
using UnityEngine;

public class HealthTextVisualisator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] public Health _health;

    private void Start()
    {
        ShowHealthStatus();
    }

    private void OnEnable()
    {
        _health.CurrentHealthChanged += ShowHealthStatus;
    }

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= ShowHealthStatus;
    }

    private void ShowHealthStatus()
    {
        _textMesh.text = _health.CurrentHealth.ToString() + " / "
            + _health.MaxHealth.ToString();
    }
}