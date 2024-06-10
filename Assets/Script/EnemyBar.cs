using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBar : MonoBehaviour
{
    public int MaxValue;
    public int Value;

    public RectTransform topBar;

    public RectTransform bottomBar;

    private float speed =10f;
    float fullWidth;
    float TargetWidth => Value * fullWidth / MaxValue;

    private Coroutine adjustBarWidthCoroutine;

    private void Start()
    {
        fullWidth = topBar.rect.width;
    }

    private IEnumerator AdjustBarWidth(int amount)
    {
        var suddenChangeBar = amount >= 0 ? bottomBar : topBar;
        var slowChangeBar = amount >= 0 ? topBar : bottomBar;
        suddenChangeBar.SetWidth(TargetWidth);
        while (Mathf.Abs(suddenChangeBar.rect.width - slowChangeBar.rect.width) > 1f)
        {
            slowChangeBar.SetWidth(Mathf.Lerp(slowChangeBar.rect.width, TargetWidth, Time.deltaTime * speed));
            yield return null;
        }
        slowChangeBar.SetWidth(TargetWidth);
    }
    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value+amount, 0, MaxValue);
        if(adjustBarWidthCoroutine != null)
        {
            StopCoroutine(adjustBarWidthCoroutine);
        }
        adjustBarWidthCoroutine= StartCoroutine(AdjustBarWidth(amount));
    }


}
