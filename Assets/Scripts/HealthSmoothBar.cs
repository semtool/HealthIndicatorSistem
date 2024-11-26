using System.Collections;
using UnityEngine;

public class HealthSmoothBar : HealthScale
{
    private Coroutine _coroutine;
    private float _volueStep = 0.2f;

    public override void ChangeBarView()
    {
        ChangeSmoothBarView(GetCurrentBarVolue());
    }

    public void ChangeSmoothBarView(float targetVolue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Move(targetVolue));
    }

    private IEnumerator Move(float targetValue)
    {
        while (_barScale.value != targetValue)
        {
            _barScale.value = Mathf.MoveTowards(_barScale.value, targetValue, _volueStep * Time.deltaTime);

            yield return null;
        }
    }
}