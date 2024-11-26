public class HealthBar : HealthScale
{
    public override void ChangeBarView()
    {
        _barScale.value = GetCurrentBarVolue();
    }
}