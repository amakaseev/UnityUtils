using UnityEngine;

namespace UnityUtils {

  [RequireComponent(typeof(RectTransform)), ExecuteInEditMode]
  public class UIFollow: MonoBehaviour {
    [Header("Follow params")]
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;

    [Header("Optional")]
    [SerializeField] Camera mainCamera;
    [SerializeField] RectTransform canvasRect;

    RectTransform rt;

    void Start() {
      if (!mainCamera) {
        mainCamera = Camera.main;
      }
      if (!canvasRect) {
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
      }

      rt = GetComponent<RectTransform>();
    }

    void LateUpdate() {
      if (objectToFollow) {
        rt.anchoredPosition = mainCamera.WorldToCanvas(objectToFollow.position + offset, canvasRect);
      }
    }

    public void SetFollow(Transform transform) {
      objectToFollow = transform;
    }

    public void SetOffset(Vector3 offset) {
      this.offset = offset;
    }
    
  }
  
}
