using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUI : MonoBehaviour
{
    [SerializeField] RectTransform barRectTransform;
    float maxWidth;

    private void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }
    private void OnEnable()
    {
        EventManager.onTakeDmg += UpdateDisplay;
        EventManager.onStartGame += UpdateDisplayStart;
    }
    private void OnDisable()
    {
        EventManager.onTakeDmg -= UpdateDisplay;
    }
    void UpdateDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 50f);
    }
    void UpdateDisplayStart()
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth, 50f);
    }

}
