using UnityEditor;
using UnityEngine;

public class SerializeInterfaceUtility
{
    private static GUIStyle _normalInterfaceLabelStyle;

    public static void DrawInterfaceNameLabel(Rect position, string displayString, int controlID)
    {
        if (Event.current.type == EventType.Repaint)
        {
            InitializeStyleIfNeeded();

            const int additionalLeftWidth = 3;
            const int verticalIndent = 1;
            var content = EditorGUIUtility.TrTextContent(displayString);
            var size = _normalInterfaceLabelStyle.CalcSize(content);
            var interfaceLabelPosition = position;
            interfaceLabelPosition.width = size.x + additionalLeftWidth;
            interfaceLabelPosition.x += position.width - interfaceLabelPosition.width - 18;
            interfaceLabelPosition.height = interfaceLabelPosition.height - verticalIndent * 2;
            interfaceLabelPosition.y += verticalIndent;
            _normalInterfaceLabelStyle.Draw(interfaceLabelPosition, EditorGUIUtility.TrTextContent(displayString), controlID, DragAndDrop.activeControlID == controlID, false);
        }
    }

    private static void InitializeStyleIfNeeded()
    {
        if (_normalInterfaceLabelStyle != null)
            return;

        _normalInterfaceLabelStyle = new GUIStyle(EditorStyles.label);
        var objectFieldStyle = EditorStyles.objectField;
        _normalInterfaceLabelStyle.font = objectFieldStyle.font;
        _normalInterfaceLabelStyle.fontSize = objectFieldStyle.fontSize;
        _normalInterfaceLabelStyle.fontStyle = objectFieldStyle.fontStyle;
        _normalInterfaceLabelStyle.alignment = TextAnchor.MiddleRight;
        _normalInterfaceLabelStyle.padding = new RectOffset(0, 2, 0, 0);
        var texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(40 / 255f, 40 / 255f, 40 / 255f));
        texture.Apply();
        _normalInterfaceLabelStyle.normal.background = texture;
    }
}