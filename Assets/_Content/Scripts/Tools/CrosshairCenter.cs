using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CrosshairCenter : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        CenterCrosshair();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CenterCrosshair();
    }

    private void CenterCrosshair()
    {
        if (rectTransform == null) return;

        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
    }
}