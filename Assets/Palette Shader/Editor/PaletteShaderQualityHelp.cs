using UnityEditor;
using UnityEngine;

public class PaletteShaderQualityHelp : EditorWindow {

	//On GUI.
	void OnGUI() {
        GUILayoutOption[] emptyGUILayoutOption = new GUILayoutOption[0];
        GUILayoutOption[][] tableCellWidths = {
            new GUILayoutOption[] { GUILayout.Width(position.width * 0.3f) },
            new GUILayoutOption[] { GUILayout.Width(position.width * 0.3f) },
            new GUILayoutOption[] { GUILayout.Width(position.width * 0.3f) }
        };
        GUIStyle boldLabel = new GUIStyle(GUI.skin.label);
        boldLabel.fontStyle = FontStyle.Bold;
        boldLabel.alignment = TextAnchor.MiddleCenter;
        GUIStyle normalText = new GUIStyle(GUI.skin.label);
        normalText.wordWrap = true;
        GUIStyle tableCell = new GUIStyle(GUI.skin.label);
        tableCell.alignment = TextAnchor.MiddleCenter;
        EditorGUILayout.LabelField("Palette Shader - Quality", boldLabel, emptyGUILayoutOption);
        EditorGUILayout.GetControlRect(emptyGUILayoutOption);
        EditorGUILayout.LabelField("The quality field is used to set the size of the palette texture used by Palette Shader. The quality can be set between " +
                "four and eight bits per RGB colour channel. A higher number of bits per channel produces a more accurate texture, thus more accurate " +
                "colouring, but takes up more memory and will take longer to generate when the program runs. Because palettes are used to restrict the " +
                "number of colours available, the default six bits per RGB channel is often sufficient. The table below gives a rough guide to what each " +
                "quality level is capable of:", normalText, emptyGUILayoutOption);
        EditorGUILayout.GetControlRect(emptyGUILayoutOption);
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("Bits Per Channel", boldLabel, tableCellWidths[0]);
        EditorGUILayout.LabelField("Distinct Colours", boldLabel, tableCellWidths[1]);
        EditorGUILayout.LabelField("Memory Required", boldLabel, tableCellWidths[1]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("4", tableCell, tableCellWidths[0]);
        EditorGUILayout.LabelField("4,096", tableCell, tableCellWidths[1]);
        EditorGUILayout.LabelField(EditorUtility.FormatBytes(12288), tableCell, tableCellWidths[2]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("5", tableCell, tableCellWidths[0]);
        EditorGUILayout.LabelField("32,768", tableCell, tableCellWidths[1]);
        EditorGUILayout.LabelField(EditorUtility.FormatBytes(98304), tableCell, tableCellWidths[2]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("6", tableCell, tableCellWidths[0]);
        EditorGUILayout.LabelField("262,144", tableCell, tableCellWidths[1]);
        EditorGUILayout.LabelField(EditorUtility.FormatBytes(786432), tableCell, tableCellWidths[2]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("7", tableCell, tableCellWidths[0]);
        EditorGUILayout.LabelField("2,097,152", tableCell, tableCellWidths[1]);
        EditorGUILayout.LabelField(EditorUtility.FormatBytes(6291456), tableCell, tableCellWidths[2]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(emptyGUILayoutOption);
        EditorGUILayout.LabelField("8", tableCell, tableCellWidths[0]);
        EditorGUILayout.LabelField("16,777,216", tableCell, tableCellWidths[1]);
        EditorGUILayout.LabelField(EditorUtility.FormatBytes(50331648), tableCell, tableCellWidths[2]);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.GetControlRect(emptyGUILayoutOption);
        EditorGUILayout.LabelField("When selecting a quality level, go for the lowest number of bits per channel that doesn't compromise the final image. " +
                "Note that every time an extra bit per channel is added, the memory required and, in theory, time taken to generate the texture will both " +
                "increase 8-fold!", normalText, emptyGUILayoutOption);
        EditorGUILayout.GetControlRect(emptyGUILayoutOption);
        EditorGUILayout.LabelField("In the Unity Editor, you can see the time taken to generate the texture by switching on \"Time Diagnostics\" on the " +
                "Palette Shader component and running the scene. Doing this reports the time in the console.", normalText, emptyGUILayoutOption);
    }	
}
