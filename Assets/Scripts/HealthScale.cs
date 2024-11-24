using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthScale : MonoBehaviour
{
    public Slider BarScale { get; private set; }

    private void Awake()
    {
        BarScale = GetComponent<Slider>();
    }
}