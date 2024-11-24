using System.Collections;
using UnityEngine;

public class HealthSmoothBar : HealthScale
{
    private Coroutine _coroutine;
    private float _volueStep = 0.2f;

    public void ChangeSmoothBarView(float targetVolue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Move(targetVolue));
    }

    private IEnumerator Move(float targetVolue)
    {
        while (BarScale.value != targetVolue)
        {
            BarScale.value = Mathf.MoveTowards(BarScale.value, targetVolue, _volueStep * Time.deltaTime);

            yield return null;
        }
    }
}