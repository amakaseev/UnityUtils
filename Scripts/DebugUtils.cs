using UnityEngine;

public static class DebugUtils {

  public static void Log(string text, Color color) {
    Debug.Log($"<font color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</font>");
  }

  public static void Log(string prefix, Color color, string text) {
    Debug.Log($"<font color=#{ColorUtility.ToHtmlStringRGB(color)}>{prefix}</font>{text}");
  }

  public static void LogFSM(string text) {
    Log("[FSM]", Color.yellow, ": " + text);
  }

  public static void LogFSM(object obj, string text) {
    LogFSM($"{obj.GetType()}" + text);
  }
}
