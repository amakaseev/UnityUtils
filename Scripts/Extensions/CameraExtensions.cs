using UnityEngine;

namespace UnityUtils {

  public static class CameraExtensions {
    static public Vector2 WorldToCanvas(this Camera camera, Vector3 worldPosition, RectTransform canvasRect) {
      var viewport_position = camera.WorldToViewportPoint(worldPosition);
      return new Vector2(
        (viewport_position.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f),
        (viewport_position.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)
      );
    }
    /// <summary>
    /// Calculates and returns viewport extents with an optional margin. Useful for calculating a frustum for culling.
    /// </summary>
    /// <param name="camera">The camera object this method extends.</param>
    /// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is 0.2, 0.2.</param>
    /// <returns>Viewport extents as a Vector2 after applying the margin.</returns>
    public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null) {
      Vector2 margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

      Vector2 result;
      float halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
      result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
      result.x = result.y * camera.aspect + margin.x;
      result.y += margin.y;
      return result;
    }
  }

}