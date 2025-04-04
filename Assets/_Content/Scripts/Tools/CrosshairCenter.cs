using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CrosshairCenter : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        CenterCrosshair();
    }

#if UNITY_EDITOR
    void Update()
    {
        // Useful in editor to auto-update if screen size changes
        CenterCrosshair();
    }
#endif

    private void CenterCrosshair()
    {
        if (rectTransform == null) return;

        // Anchors in the middle of screen
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
    }
}