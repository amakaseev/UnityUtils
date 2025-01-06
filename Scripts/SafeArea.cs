using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour {
  [SerializeField] bool enable = true;
  [SerializeField, Range(0f, 1f)] float topPaddingMultiplier = 1f; // Влияние верхнего паддинга на отступ от начала экрана
  [SerializeField, Range(0f, 1f)] float bottomPaddingMultiplier = 1f; // Влияние нижнего паддинга на нижнюю границу safe area

  RectTransform rectTransform;
  bool needsUpdate = false;

  void Awake() {
    rectTransform = GetComponent<RectTransform>();
    needsUpdate = true;
  }

  void OnEnable() {
    needsUpdate = true;
  }

  void OnValidate() {
    needsUpdate = true;
  }

  void Update() {
    if (needsUpdate) {
      ApplySafeArea();
      needsUpdate = false;
    }
  }

  void ApplySafeArea() {
    if (!enable || rectTransform == null) return;

    Rect safeArea = Screen.safeArea;
    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    // Calculate adjusted anchor values
    float anchorMinY = (safeArea.yMin / screenHeight) * bottomPaddingMultiplier;
    float anchorMaxY = safeArea.yMax / screenHeight + (1 - (safeArea.yMax / screenHeight)) * (1 - topPaddingMultiplier);

    // Apply anchor values
    rectTransform.anchorMin = new Vector2(safeArea.xMin / screenWidth, anchorMinY);
    rectTransform.anchorMax = new Vector2(safeArea.xMax / screenWidth, anchorMaxY);
  }
}
