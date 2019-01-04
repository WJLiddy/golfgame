using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PaletteShader))]
public class PaletteShaderPropertyDrawer : Editor {

    //Enumerated types.
    enum Template {
        SelectTemplate,
        _8Colour,
        Autumn,
        Blues,
        Bright,
        CGA,
        Cool,
        EGA,
        Greens,
        Greyscale,
        Monochrome,
        NightVision,
        Pastel,
        Purples,
        Reds,
        Spring,
        Summer,
        VGA,
        Yellows,
        Warm,
        WebSafe,
        Winter
    };

    //Draw the inspector GUI.
    public override void OnInspectorGUI() {

        //Get the palette shader instance.
        PaletteShader paletteShader = (PaletteShader) target;

        //Keep track of whether the target object has become dirty.
        bool targetObjectDirty = false;

        //Set styles.
        GUILayoutOption[] emptyGUILayoutOptions = new GUILayoutOption[0];
        GUIStyle deleteButtonStyle = new GUIStyle(GUI.skin.button);
        deleteButtonStyle.fontStyle = FontStyle.Bold;
        deleteButtonStyle.normal.textColor = new Color(0.9f, 0, 0);
        deleteButtonStyle.active.textColor = new Color(0.9f, 0, 0);
        GUIStyle noColoursStyle = new GUIStyle(GUI.skin.label);
        noColoursStyle.alignment = TextAnchor.MiddleCenter;
        noColoursStyle.fontStyle = FontStyle.Italic;
        noColoursStyle.wordWrap = true;

        //Templates.
        Rect position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        Template template = (Template) EditorGUI.EnumPopup(position, new GUIContent("Templates", "Select the properties of this Palette Shader component " +
                "from a list of pre-set templates."), Template.SelectTemplate);
        if (template != Template.SelectTemplate) {
            Undo.RecordObject(target, "Set Palette Shader Template");
            paletteShader.individualColours.Clear();
            paletteShader.colourRanges.Clear();
            paletteShader.brightness = 0;
            paletteShader.contrast = 0;
            paletteShader.pixelation = 0;
            paletteShader.filterMode = FilterMode.Point;
            paletteShader.quality = PaletteShader.Quality._6BitsPerRGBChannel;
            if (template == Template.Cool) {
                paletteShader.brightness = 0.1f;
                paletteShader.contrast = 0.2f;
                paletteShader.individualColours.Add(new Color(0.905882f, 0.980392f, 0.905882f));
                paletteShader.individualColours.Add(new Color(0.843137f, 0.960784f, 0.85098f));
                paletteShader.individualColours.Add(new Color(0.619608f, 1.0f, 0.596078f));
                paletteShader.individualColours.Add(new Color(0.482353f, 0.984314f, 0.439216f));
                paletteShader.individualColours.Add(new Color(0.368627f, 0.929412f, 0.427451f));
                paletteShader.individualColours.Add(new Color(0.164706f, 0.976471f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.27451f, 0.886275f, 0.262745f));
                paletteShader.individualColours.Add(new Color(0.258824f, 0.705882f, 0.258824f));
                paletteShader.individualColours.Add(new Color(0.25098f, 0.560784f, 0.243137f));
                paletteShader.individualColours.Add(new Color(0.113725f, 0.415686f, 0.0941176f));
                paletteShader.individualColours.Add(new Color(0.890196f, 0.984314f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.596078f, 0.992157f, 0.968627f));
                paletteShader.individualColours.Add(new Color(0.427451f, 1.0f, 0.960784f));
                paletteShader.individualColours.Add(new Color(0.47451f, 0.968627f, 0.956863f));
                paletteShader.individualColours.Add(new Color(0.270588f, 0.992157f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.203922f, 0.952941f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.156863f, 0.768627f, 0.756863f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.698039f, 0.678431f));
                paletteShader.individualColours.Add(new Color(0.105882f, 0.466667f, 0.454902f));
                paletteShader.individualColours.Add(new Color(0.145098f, 0.282353f, 0.298039f));
                paletteShader.individualColours.Add(new Color(0.909804f, 0.901961f, 0.988235f));
                paletteShader.individualColours.Add(new Color(0.831373f, 0.819608f, 0.988235f));
                paletteShader.individualColours.Add(new Color(0.662745f, 0.666667f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.470588f, 0.466667f, 0.968627f));
                paletteShader.individualColours.Add(new Color(0.282353f, 0.286275f, 0.984314f));
                paletteShader.individualColours.Add(new Color(0.133333f, 0.121569f, 0.956863f));
                paletteShader.individualColours.Add(new Color(0.129412f, 0.14902f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.262745f, 0.270588f, 0.713726f));
                paletteShader.individualColours.Add(new Color(0.145098f, 0.137255f, 0.423529f));
                paletteShader.individualColours.Add(new Color(0.121569f, 0.129412f, 0.290196f));
                paletteShader.individualColours.Add(new Color(0.964706f, 0.831373f, 0.937255f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.803922f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.831373f, 0.666667f, 0.996078f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.505882f, 0.988235f));
                paletteShader.individualColours.Add(new Color(0.745098f, 0.12549f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.627451f, 0.145098f, 0.839216f));
                paletteShader.individualColours.Add(new Color(0.466667f, 0.227451f, 0.631373f));
                paletteShader.individualColours.Add(new Color(0.490196f, 0.117647f, 0.447059f));
                paletteShader.individualColours.Add(new Color(0.282353f, 0.121569f, 0.427451f));
                paletteShader.individualColours.Add(new Color(0.258824f, 0.141176f, 0.27451f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.862745f, 0.941176f));
                paletteShader.individualColours.Add(new Color(0.960784f, 0.823529f, 0.980392f));
                paletteShader.individualColours.Add(new Color(0.956863f, 0.635294f, 0.956863f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.490196f, 0.996078f));
                paletteShader.individualColours.Add(new Color(0.933333f, 0.301961f, 0.945098f));
                paletteShader.individualColours.Add(new Color(0.941176f, 0.145098f, 0.941176f));
                paletteShader.individualColours.Add(new Color(0.85098f, 0.301961f, 0.831373f));
                paletteShader.individualColours.Add(new Color(0.635294f, 0.439216f, 0.631373f));
                paletteShader.individualColours.Add(new Color(0.701961f, 0.282353f, 0.698039f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.27451f, 0.45098f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.886275f, 0.882353f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.819608f, 0.815686f));
                paletteShader.individualColours.Add(new Color(0.972549f, 0.635294f, 0.819608f));
                paletteShader.individualColours.Add(new Color(0.941176f, 0.407843f, 0.596078f));
                paletteShader.individualColours.Add(new Color(0.92549f, 0.278431f, 0.690196f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0823529f, 0.658824f));
                paletteShader.individualColours.Add(new Color(0.866667f, 0.121569f, 0.466667f));
                paletteShader.individualColours.Add(new Color(0.501961f, 0.184314f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.592157f, 0.117647f, 0.247059f));
                paletteShader.individualColours.Add(new Color(0.403922f, 0.129412f, 0.27451f));
            }
            else if (template == Template.Warm) {
                paletteShader.brightness = 0.05f;
                paletteShader.contrast = 0.25f;
                paletteShader.individualColours.Add(new Color(0.803922f, 0.964706f, 0.596078f));
                paletteShader.individualColours.Add(new Color(0.623529f, 1.0f, 0.415686f));
                paletteShader.individualColours.Add(new Color(0.568627f, 0.968627f, 0.403922f));
                paletteShader.individualColours.Add(new Color(0.470588f, 0.788235f, 0.180392f));
                paletteShader.individualColours.Add(new Color(0.486275f, 0.835294f, 0.0980392f));
                paletteShader.individualColours.Add(new Color(0.419608f, 0.572549f, 0.0666667f));
                paletteShader.individualColours.Add(new Color(0.231373f, 0.639216f, 0.0313726f));
                paletteShader.individualColours.Add(new Color(0.266667f, 0.431373f, 0.0392157f));
                paletteShader.individualColours.Add(new Color(0.243137f, 0.231373f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.141176f, 0.294118f, 0.121569f));
                paletteShader.individualColours.Add(new Color(0.988235f, 1.0f, 0.690196f));
                paletteShader.individualColours.Add(new Color(0.980392f, 0.996078f, 0.52549f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.996078f, 0.282353f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.984314f, 0.172549f));
                paletteShader.individualColours.Add(new Color(0.827451f, 0.843137f, 0.270588f));
                paletteShader.individualColours.Add(new Color(0.686275f, 0.713726f, 0.258824f));
                paletteShader.individualColours.Add(new Color(0.827451f, 0.811765f, 0.0941176f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.647059f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.462745f, 0.478431f, 0.14902f));
                paletteShader.individualColours.Add(new Color(0.301961f, 0.294118f, 0.133333f));
                paletteShader.individualColours.Add(new Color(0.988235f, 0.988235f, 0.839216f));
                paletteShader.individualColours.Add(new Color(0.984314f, 0.835294f, 0.556863f));
                paletteShader.individualColours.Add(new Color(0.980392f, 0.839216f, 0.470588f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.803922f, 0.290196f));
                paletteShader.individualColours.Add(new Color(0.964706f, 0.843137f, 0.141176f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.666667f, 0.219608f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.8f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.792157f, 0.623529f, 0.0784314f));
                paletteShader.individualColours.Add(new Color(0.807843f, 0.65098f, 0.458824f));
                paletteShader.individualColours.Add(new Color(0.811765f, 0.627451f, 0.282353f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.988235f, 0.827451f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.992157f, 0.843137f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.815686f, 0.65098f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.619608f, 0.541176f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.619608f, 0.431373f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.666667f, 0.298039f));
                paletteShader.individualColours.Add(new Color(0.976471f, 0.733333f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.682353f, 0.262745f));
                paletteShader.individualColours.Add(new Color(0.839216f, 0.462745f, 0.305882f));
                paletteShader.individualColours.Add(new Color(0.658824f, 0.470588f, 0.313726f));
                paletteShader.individualColours.Add(new Color(0.988235f, 0.941176f, 0.941176f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.796078f, 0.792157f));
                paletteShader.individualColours.Add(new Color(0.976471f, 0.623529f, 0.658824f));
                paletteShader.individualColours.Add(new Color(0.956863f, 0.639216f, 0.431373f));
                paletteShader.individualColours.Add(new Color(0.976471f, 0.505882f, 0.298039f));
                paletteShader.individualColours.Add(new Color(0.980392f, 0.482353f, 0.172549f));
                paletteShader.individualColours.Add(new Color(0.980392f, 0.403922f, 0.141176f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.454902f, 0.141176f));
                paletteShader.individualColours.Add(new Color(0.815686f, 0.266667f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.603922f, 0.282353f, 0.12549f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.92549f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.968627f, 0.796078f, 0.792157f));
                paletteShader.individualColours.Add(new Color(0.968627f, 0.592157f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.94902f, 0.423529f, 0.380392f));
                paletteShader.individualColours.Add(new Color(0.988235f, 0.239216f, 0.266667f));
                paletteShader.individualColours.Add(new Color(0.952941f, 0.0627451f, 0.0392157f));
                paletteShader.individualColours.Add(new Color(0.843137f, 0.0666667f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.686275f, 0.172549f, 0.196078f));
                paletteShader.individualColours.Add(new Color(0.396078f, 0.0784314f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.227451f, 0.0627451f, 0.0705882f));
            }
            else if (template == Template.Summer) {
                paletteShader.brightness = 0.25f;
                paletteShader.contrast = 0.25f;
                paletteShader.individualColours.Add(new Color(0.756863f, 0.678431f, 0.580392f));
                paletteShader.individualColours.Add(new Color(0.619608f, 0.658824f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.823529f, 0.592157f, 0.678431f));
                paletteShader.individualColours.Add(new Color(0.721569f, 0.666667f, 0.47451f));
                paletteShader.individualColours.Add(new Color(0.470588f, 0.615686f, 0.588235f));
                paletteShader.individualColours.Add(new Color(0.788235f, 0.427451f, 0.580392f));
                paletteShader.individualColours.Add(new Color(0.501961f, 0.411765f, 0.341176f));
                paletteShader.individualColours.Add(new Color(0.407843f, 0.47451f, 0.584314f));
                paletteShader.individualColours.Add(new Color(0.752941f, 0.184314f, 0.352941f));
                paletteShader.individualColours.Add(new Color(0.909804f, 0.8f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.278431f, 0.321569f, 0.498039f));
                paletteShader.individualColours.Add(new Color(0.67451f, 0.12549f, 0.278431f));
                paletteShader.individualColours.Add(new Color(0.941176f, 0.94902f, 0.568627f));
                paletteShader.individualColours.Add(new Color(0.262745f, 0.223529f, 0.356863f));
                paletteShader.individualColours.Add(new Color(0.447059f, 0.0627451f, 0.247059f));
                paletteShader.individualColours.Add(new Color(0.337255f, 0.556863f, 0.372549f));
                paletteShader.individualColours.Add(new Color(0.109804f, 0.0941176f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.454902f, 0.537255f));
                paletteShader.individualColours.Add(new Color(0.0235294f, 0.384314f, 0.341176f));
                paletteShader.individualColours.Add(new Color(0.376471f, 0.32549f, 0.505882f));
                paletteShader.individualColours.Add(new Color(0.698039f, 0.372549f, 0.545098f));
                paletteShader.individualColours.Add(new Color(0.290196f, 0.505882f, 0.423529f));
                paletteShader.individualColours.Add(new Color(0.552941f, 0.443137f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.321569f, 0.305882f, 0.301961f));
                paletteShader.individualColours.Add(new Color(0.258824f, 0.592157f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.721569f, 0.705882f));
                paletteShader.individualColours.Add(new Color(0.913725f, 0.188235f, 0.243137f));
                paletteShader.individualColours.Add(new Color(0.85098f, 0.992157f, 0.952941f));
            }
            else if (template == Template.Autumn) {
                paletteShader.brightness = 0.1f;
                paletteShader.contrast = 0.25f;
                paletteShader.individualColours.Add(new Color(0.419608f, 0.392157f, 0.211765f));
                paletteShader.individualColours.Add(new Color(0.670588f, 0.290196f, 0.0823529f));
                paletteShader.individualColours.Add(new Color(0.45098f, 0.141176f, 0.262745f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.341176f, 0.0980392f));
                paletteShader.individualColours.Add(new Color(0.835294f, 0.313726f, 0.137255f));
                paletteShader.individualColours.Add(new Color(0.372549f, 0.172549f, 0.239216f));
                paletteShader.individualColours.Add(new Color(0.239216f, 0.368627f, 0.160784f));
                paletteShader.individualColours.Add(new Color(0.74902f, 0.478431f, 0.113725f));
                paletteShader.individualColours.Add(new Color(0.584314f, 0.458824f, 0.407843f));
                paletteShader.individualColours.Add(new Color(0.611765f, 0.627451f, 0.294118f));
                paletteShader.individualColours.Add(new Color(0.823529f, 0.592157f, 0.0823529f));
                paletteShader.individualColours.Add(new Color(0.870588f, 0.533333f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.588235f, 0.545098f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.678431f, 0.478431f, 0.0588235f));
                paletteShader.individualColours.Add(new Color(0.905882f, 0.407843f, 0.47451f));
                paletteShader.individualColours.Add(new Color(0.372549f, 0.443137f, 0.356863f));
                paletteShader.individualColours.Add(new Color(0.341176f, 0.160784f, 0.101961f));
                paletteShader.individualColours.Add(new Color(0.592157f, 0.0666667f, 0.196078f));
                paletteShader.individualColours.Add(new Color(0.105882f, 0.137255f, 0.219608f));
                paletteShader.individualColours.Add(new Color(0.372549f, 0.27451f, 0.156863f));
                paletteShader.individualColours.Add(new Color(0.423529f, 0.0823529f, 0.145098f));
                paletteShader.individualColours.Add(new Color(0.0156863f, 0.188235f, 0.286275f));
                paletteShader.individualColours.Add(new Color(0.639216f, 0.501961f, 0.290196f));
                paletteShader.individualColours.Add(new Color(0.752941f, 0.219608f, 0.266667f));
                paletteShader.individualColours.Add(new Color(0.184314f, 0.498039f, 0.486275f));
                paletteShader.individualColours.Add(new Color(0.760784f, 0.647059f, 0.47451f));
                paletteShader.individualColours.Add(new Color(0.901961f, 0.196078f, 0.239216f));
                paletteShader.individualColours.Add(new Color(0.278431f, 0.184314f, 0.286275f));
            }
            else if (template == Template.Winter) {
                paletteShader.brightness = 0.2f;
                paletteShader.contrast = 0.15f;
                paletteShader.individualColours.Add(new Color(0.647059f, 0.584314f, 0.352941f));
                paletteShader.individualColours.Add(new Color(0.505882f, 0.2f, 0.529412f));
                paletteShader.individualColours.Add(new Color(0.627451f, 0.490196f, 0.513726f));
                paletteShader.individualColours.Add(new Color(0.607843f, 0.54902f, 0.427451f));
                paletteShader.individualColours.Add(new Color(0.231373f, 0.0666667f, 0.247059f));
                paletteShader.individualColours.Add(new Color(0.470588f, 0.364706f, 0.392157f));
                paletteShader.individualColours.Add(new Color(0.584314f, 0.517647f, 0.415686f));
                paletteShader.individualColours.Add(new Color(0.172549f, 0.0980392f, 0.184314f));
                paletteShader.individualColours.Add(new Color(0.584314f, 0.0941176f, 0.211765f));
                paletteShader.individualColours.Add(new Color(0.482353f, 0.486275f, 0.431373f));
                paletteShader.individualColours.Add(new Color(0.113725f, 0.054902f, 0.137255f));
                paletteShader.individualColours.Add(new Color(0.403922f, 0.0705882f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.490196f, 0.541176f, 0.513726f));
                paletteShader.individualColours.Add(new Color(0.0588235f, 0.184314f, 0.470588f));
                paletteShader.individualColours.Add(new Color(0.419608f, 0.0745098f, 0.27451f));
                paletteShader.individualColours.Add(new Color(0.286275f, 0.313726f, 0.337255f));
                paletteShader.individualColours.Add(new Color(0.0627451f, 0.0980392f, 0.352941f));
                paletteShader.individualColours.Add(new Color(0.517647f, 0.105882f, 0.32549f));
                paletteShader.individualColours.Add(new Color(0.0745098f, 0.133333f, 0.215686f));
                paletteShader.individualColours.Add(new Color(0.0666667f, 0.356863f, 0.501961f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.168627f, 0.478431f));
                paletteShader.individualColours.Add(new Color(0.0980392f, 0.0862745f, 0.160784f));
                paletteShader.individualColours.Add(new Color(0.0745098f, 0.443137f, 0.552941f));
                paletteShader.individualColours.Add(new Color(0.74902f, 0.376471f, 0.541176f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.00392157f, 0.0196078f));
                paletteShader.individualColours.Add(new Color(0.501961f, 0.541176f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0666667f, 0.380392f, 0.266667f));
            }
            else if (template == Template.Spring) {
                paletteShader.brightness = 0.25f;
                paletteShader.contrast = 0.2f;
                paletteShader.individualColours.Add(new Color(0.92549f, 0.823529f, 0.529412f));
                paletteShader.individualColours.Add(new Color(0.941176f, 0.717647f, 0.741176f));
                paletteShader.individualColours.Add(new Color(0.635294f, 0.760784f, 0.741176f));
                paletteShader.individualColours.Add(new Color(0.921569f, 0.823529f, 0.603922f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.443137f, 0.498039f));
                paletteShader.individualColours.Add(new Color(0.309804f, 0.658824f, 0.815686f));
                paletteShader.individualColours.Add(new Color(0.862745f, 0.760784f, 0.470588f));
                paletteShader.individualColours.Add(new Color(0.92549f, 0.313726f, 0.470588f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.827451f, 0.85098f));
                paletteShader.individualColours.Add(new Color(0.87451f, 0.729412f, 0.462745f));
                paletteShader.individualColours.Add(new Color(0.886275f, 0.176471f, 0.211765f));
                paletteShader.individualColours.Add(new Color(0.376471f, 0.498039f, 0.721569f));
                paletteShader.individualColours.Add(new Color(0.776471f, 0.584314f, 0.356863f));
                paletteShader.individualColours.Add(new Color(0.854902f, 0.129412f, 0.117647f));
                paletteShader.individualColours.Add(new Color(0.298039f, 0.329412f, 0.482353f));
                paletteShader.individualColours.Add(new Color(0.596078f, 0.188235f, 0.0901961f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.345098f, 0.482353f));
                paletteShader.individualColours.Add(new Color(0.552941f, 0.537255f, 0.737255f));
                paletteShader.individualColours.Add(new Color(0.466667f, 0.745098f, 0.431373f));
                paletteShader.individualColours.Add(new Color(0.933333f, 0.494118f, 0.54902f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.623529f, 0.788235f));
                paletteShader.individualColours.Add(new Color(0.419608f, 0.752941f, 0.588235f));
                paletteShader.individualColours.Add(new Color(0.92549f, 0.721569f, 0.678431f));
                paletteShader.individualColours.Add(new Color(0.458824f, 0.282353f, 0.615686f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.858824f, 0.47451f));
                paletteShader.individualColours.Add(new Color(0.921569f, 0.662745f, 0.607843f));
                paletteShader.individualColours.Add(new Color(0.643137f, 0.376471f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.972549f, 0.972549f, 0.627451f));
            }
            else if (template == Template.Reds) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(1.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template.Greens) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(0.0f, 1.0f, 0.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template.Blues) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(0.0f, 0.0f, 1.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template.Yellows) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(1.0f, 1.0f, 0.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template.Purples) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(1.0f, 0.0f, 1.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template._8Colour) {
                paletteShader.brightness = 0.2f;
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
            }
            else if (template == Template.NightVision) {
                paletteShader.brightness = -0.3f;
                paletteShader.contrast = -0.3f;
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(0.0f, 0.5f, 0.0f);
                paletteShader.colourRanges[0].steps = 255;
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[1].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[1].endColour = new Color(0.1f, 0.5f, 0.1f);
                paletteShader.colourRanges[1].steps = 255;
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[2].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[2].endColour = new Color(0.2f, 0.5f, 0.2f);
                paletteShader.colourRanges[2].steps = 255;
            }
            else if (template == Template.Bright) {
                paletteShader.brightness = 0.25f;
                paletteShader.contrast = 0.5f;
                paletteShader.individualColours.Add(new Color(0.215686f, 0.101961f, 0.282353f));
                paletteShader.individualColours.Add(new Color(0.32549f, 0.168627f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.764706f, 0.639216f, 0.901961f));
                paletteShader.individualColours.Add(new Color(0.796078f, 0.741176f, 0.792157f));
                paletteShader.individualColours.Add(new Color(0.835294f, 0.486275f, 0.67451f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.207843f, 0.466667f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.647059f, 0.592157f));
                paletteShader.individualColours.Add(new Color(0.678431f, 0.027451f, 0.278431f));
                paletteShader.individualColours.Add(new Color(0.505882f, 0.00784314f, 0.32549f));
                paletteShader.individualColours.Add(new Color(0.690196f, 0.8f, 0.572549f));
                paletteShader.individualColours.Add(new Color(0.827451f, 0.835294f, 0.752941f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.933333f, 0.529412f));
                paletteShader.individualColours.Add(new Color(0.933333f, 0.94902f, 0.027451f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.941176f, 0.498039f));
                paletteShader.individualColours.Add(new Color(0.996078f, 0.682353f, 0.00392157f));
                paletteShader.individualColours.Add(new Color(0.945098f, 0.247059f, 0.00392157f));
                paletteShader.individualColours.Add(new Color(0.823529f, 0.0235294f, 0.027451f));
                paletteShader.individualColours.Add(new Color(0.207843f, 0.0627451f, 0.0941176f));
                paletteShader.individualColours.Add(new Color(0.776471f, 0.847059f, 0.862745f));
                paletteShader.individualColours.Add(new Color(0.662745f, 0.698039f, 0.717647f));
                paletteShader.individualColours.Add(new Color(0.835294f, 0.741176f, 0.647059f));
                paletteShader.individualColours.Add(new Color(0.556863f, 0.603922f, 0.462745f));
                paletteShader.individualColours.Add(new Color(0.341176f, 0.490196f, 0.345098f));
                paletteShader.individualColours.Add(new Color(0.309804f, 0.352941f, 0.227451f));
                paletteShader.individualColours.Add(new Color(0.498039f, 0.368627f, 0.239216f));
                paletteShader.individualColours.Add(new Color(0.945098f, 0.415686f, 0.337255f));
                paletteShader.individualColours.Add(new Color(0.172549f, 0.105882f, 0.0666667f));
                paletteShader.individualColours.Add(new Color(0.121569f, 0.121569f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.172549f, 0.243137f, 0.337255f));
                paletteShader.individualColours.Add(new Color(0.380392f, 0.4f, 0.486275f));
                paletteShader.individualColours.Add(new Color(0.439216f, 0.6f, 0.686275f));
                paletteShader.individualColours.Add(new Color(0.364706f, 0.239216f, 0.768627f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.517647f, 0.760784f));
                paletteShader.individualColours.Add(new Color(0.054902f, 0.784314f, 0.733333f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.603922f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.215686f, 0.337255f, 0.34902f));
            }
            else if (template == Template.Pastel) {
                paletteShader.brightness = 0.25f;
                paletteShader.contrast = 0.25f;
                paletteShader.individualColours.Add(new Color(0.858824f, 0.54902f, 0.545098f));
                paletteShader.individualColours.Add(new Color(0.854902f, 0.67451f, 0.541176f));
                paletteShader.individualColours.Add(new Color(0.85098f, 0.803922f, 0.533333f));
                paletteShader.individualColours.Add(new Color(0.776471f, 0.854902f, 0.533333f));
                paletteShader.individualColours.Add(new Color(0.647059f, 0.854902f, 0.533333f));
                paletteShader.individualColours.Add(new Color(0.537255f, 0.854902f, 0.564706f));
                paletteShader.individualColours.Add(new Color(0.537255f, 0.854902f, 0.698039f));
                paletteShader.individualColours.Add(new Color(0.537255f, 0.85098f, 0.827451f));
                paletteShader.individualColours.Add(new Color(0.541176f, 0.74902f, 0.854902f));
                paletteShader.individualColours.Add(new Color(0.545098f, 0.619608f, 0.858824f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.541176f, 0.858824f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.541176f, 0.858824f));
                paletteShader.individualColours.Add(new Color(0.894118f, 0.596078f, 0.592157f));
                paletteShader.individualColours.Add(new Color(0.890196f, 0.717647f, 0.588235f));
                paletteShader.individualColours.Add(new Color(0.886275f, 0.843137f, 0.580392f));
                paletteShader.individualColours.Add(new Color(0.815686f, 0.890196f, 0.580392f));
                paletteShader.individualColours.Add(new Color(0.690196f, 0.890196f, 0.584314f));
                paletteShader.individualColours.Add(new Color(0.588235f, 0.890196f, 0.607843f));
                paletteShader.individualColours.Add(new Color(0.588235f, 0.890196f, 0.737255f));
                paletteShader.individualColours.Add(new Color(0.584314f, 0.886275f, 0.862745f));
                paletteShader.individualColours.Add(new Color(0.588235f, 0.788235f, 0.890196f));
                paletteShader.individualColours.Add(new Color(0.592157f, 0.662745f, 0.894118f));
                paletteShader.individualColours.Add(new Color(0.643137f, 0.588235f, 0.894118f));
                paletteShader.individualColours.Add(new Color(0.768627f, 0.588235f, 0.894118f));
                paletteShader.individualColours.Add(new Color(0.929412f, 0.658824f, 0.654902f));
                paletteShader.individualColours.Add(new Color(0.929412f, 0.768627f, 0.65098f));
                paletteShader.individualColours.Add(new Color(0.92549f, 0.882353f, 0.647059f));
                paletteShader.individualColours.Add(new Color(0.858824f, 0.929412f, 0.647059f));
                paletteShader.individualColours.Add(new Color(0.741176f, 0.929412f, 0.647059f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.929412f, 0.67451f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.929412f, 0.788235f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.92549f, 0.901961f));
                paletteShader.individualColours.Add(new Color(0.65098f, 0.835294f, 0.929412f));
                paletteShader.individualColours.Add(new Color(0.654902f, 0.721569f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.701961f, 0.65098f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.815686f, 0.65098f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.956863f, 0.729412f, 0.72549f));
                paletteShader.individualColours.Add(new Color(0.956863f, 0.823529f, 0.721569f));
                paletteShader.individualColours.Add(new Color(0.952941f, 0.921569f, 0.721569f));
                paletteShader.individualColours.Add(new Color(0.898039f, 0.956863f, 0.717647f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.956863f, 0.721569f));
                paletteShader.individualColours.Add(new Color(0.721569f, 0.956863f, 0.741176f));
                paletteShader.individualColours.Add(new Color(0.721569f, 0.956863f, 0.839216f));
                paletteShader.individualColours.Add(new Color(0.721569f, 0.952941f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.72549f, 0.878431f, 0.956863f));
                paletteShader.individualColours.Add(new Color(0.72549f, 0.780392f, 0.960784f));
                paletteShader.individualColours.Add(new Color(0.764706f, 0.72549f, 0.960784f));
                paletteShader.individualColours.Add(new Color(0.862745f, 0.72549f, 0.960784f));
                paletteShader.individualColours.Add(new Color(0.976471f, 0.788235f, 0.784314f));
                paletteShader.individualColours.Add(new Color(0.976471f, 0.866667f, 0.784314f));
                paletteShader.individualColours.Add(new Color(0.972549f, 0.945098f, 0.780392f));
                paletteShader.individualColours.Add(new Color(0.92549f, 0.976471f, 0.780392f));
                paletteShader.individualColours.Add(new Color(0.847059f, 0.976471f, 0.780392f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.976471f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.976471f, 0.882353f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.972549f, 0.956863f));
                paletteShader.individualColours.Add(new Color(0.784314f, 0.913725f, 0.976471f));
                paletteShader.individualColours.Add(new Color(0.788235f, 0.831373f, 0.976471f));
                paletteShader.individualColours.Add(new Color(0.819608f, 0.784314f, 0.980392f));
                paletteShader.individualColours.Add(new Color(0.901961f, 0.784314f, 0.976471f));
                paletteShader.individualColours.Add(new Color(0.992157f, 0.87451f, 0.87451f));
                paletteShader.individualColours.Add(new Color(0.988235f, 0.921569f, 0.870588f));
                paletteShader.individualColours.Add(new Color(0.988235f, 0.968627f, 0.870588f));
                paletteShader.individualColours.Add(new Color(0.960784f, 0.992157f, 0.870588f));
                paletteShader.individualColours.Add(new Color(0.913725f, 0.992157f, 0.870588f));
                paletteShader.individualColours.Add(new Color(0.870588f, 0.992157f, 0.878431f));
                paletteShader.individualColours.Add(new Color(0.870588f, 0.988235f, 0.933333f));
                paletteShader.individualColours.Add(new Color(0.870588f, 0.988235f, 0.980392f));
                paletteShader.individualColours.Add(new Color(0.870588f, 0.952941f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.87451f, 0.901961f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.894118f, 0.870588f, 0.992157f));
                paletteShader.individualColours.Add(new Color(0.941176f, 0.870588f, 0.992157f));
            }
            else if (template == Template.Monochrome) {
                paletteShader.brightness = 0.15f;
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
            }
            else if (template == Template.Greyscale) {
                paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
                paletteShader.colourRanges[0].startColour = new Color(0.0f, 0.0f, 0.0f);
                paletteShader.colourRanges[0].endColour = new Color(1.0f, 1.0f, 1.0f);
                paletteShader.colourRanges[0].steps = 255;
            }
            else if (template == Template.CGA) {
                paletteShader.brightness = 0.15f;
                paletteShader.contrast = 0.5f;
                paletteShader.pixelation = 0.2f;
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
            }
            else if (template == Template.EGA) {
                paletteShader.brightness = 0.15f;
                paletteShader.contrast = 0.5f;
                paletteShader.pixelation = 0.1f;
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.333333f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.666667f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.666667f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.666667f, 1.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 0.666667f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.666667f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.666667f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
            }
            else if (template == Template.VGA) {
                paletteShader.brightness = 0.15f;
                paletteShader.contrast = 0.5f;
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.0f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.333333f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.333333f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0627451f, 0.0627451f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.12549f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.207843f, 0.207843f, 0.207843f));
                paletteShader.individualColours.Add(new Color(0.270588f, 0.270588f, 0.270588f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.333333f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.396078f, 0.396078f, 0.396078f));
                paletteShader.individualColours.Add(new Color(0.458824f, 0.458824f, 0.458824f));
                paletteShader.individualColours.Add(new Color(0.541176f, 0.541176f, 0.541176f));
                paletteShader.individualColours.Add(new Color(0.603922f, 0.603922f, 0.603922f));
                paletteShader.individualColours.Add(new Color(0.666667f, 0.666667f, 0.666667f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.729412f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.792157f, 0.792157f, 0.792157f));
                paletteShader.individualColours.Add(new Color(0.87451f, 0.87451f, 0.87451f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.937255f, 0.937255f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.745098f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.745098f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.745098f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.745098f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.745098f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.745098f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.619608f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.745098f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.87451f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 0.87451f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 0.745098f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 0.619608f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.509804f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.619608f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.745098f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.87451f, 0.509804f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.87451f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.745098f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.619608f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 0.509804f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 0.619608f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 0.745098f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 0.87451f));
                paletteShader.individualColours.Add(new Color(0.509804f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 0.87451f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 0.745098f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.509804f, 0.619608f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.729412f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.792157f, 0.729412f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.87451f, 0.729412f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.937255f, 0.729412f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.729412f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.729412f, 0.937255f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.729412f, 0.87451f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.729412f, 0.792157f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.729412f, 0.729412f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.792157f, 0.729412f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.87451f, 0.729412f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.937255f, 0.729412f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.937255f, 1.0f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.87451f, 1.0f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.792157f, 1.0f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.729412f, 1.0f, 0.729412f));
                paletteShader.individualColours.Add(new Color(0.729412f, 1.0f, 0.792157f));
                paletteShader.individualColours.Add(new Color(0.729412f, 1.0f, 0.87451f));
                paletteShader.individualColours.Add(new Color(0.729412f, 1.0f, 0.937255f));
                paletteShader.individualColours.Add(new Color(0.729412f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.937255f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.87451f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.729412f, 0.792157f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.109804f, 0.0f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.0f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.0f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.0f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.0f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.0f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.0f, 0.109804f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.109804f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.333333f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.443137f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.443137f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.109804f, 0.443137f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.443137f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.443137f, 0.109804f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.443137f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.443137f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.333333f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.109804f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.270588f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.380392f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.380392f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.270588f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.223529f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.270588f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.333333f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.380392f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.380392f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.333333f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.270588f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.270588f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.333333f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.380392f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.443137f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.380392f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.333333f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.270588f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.317647f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.34902f, 0.317647f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.380392f, 0.317647f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.411765f, 0.317647f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.317647f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.317647f, 0.411765f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.317647f, 0.380392f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.317647f, 0.34902f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.317647f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.34902f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.380392f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.411765f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.443137f, 0.443137f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.411765f, 0.443137f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.380392f, 0.443137f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.34902f, 0.443137f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.443137f, 0.317647f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.443137f, 0.34902f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.443137f, 0.380392f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.443137f, 0.411765f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.443137f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.411765f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.380392f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.317647f, 0.34902f, 0.443137f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0627451f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.0627451f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.192157f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0627451f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 0.0627451f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.254902f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.192157f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0627451f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.156863f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.156863f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.12549f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.156863f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.192157f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.223529f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.223529f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.156863f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.12549f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.156863f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.223529f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.254902f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.223529f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.192157f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.12549f, 0.156863f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.176471f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.176471f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.207843f, 0.176471f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.239216f, 0.176471f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.176471f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.176471f, 0.239216f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.176471f, 0.207843f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.176471f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.176471f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.192157f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.207843f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.239216f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.254902f, 0.254902f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.239216f, 0.254902f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.207843f, 0.254902f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.192157f, 0.254902f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.254902f, 0.176471f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.254902f, 0.192157f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.254902f, 0.207843f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.254902f, 0.239216f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.254902f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.239216f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.207843f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.176471f, 0.192157f, 0.254902f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
            }
            else if (template == Template.WebSafe) {
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(1.0f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.8f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.6f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.4f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.2f, 0.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 1.0f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.8f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.6f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.4f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.2f, 0.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 1.0f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.8f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.6f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.4f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.2f));
                paletteShader.individualColours.Add(new Color(0.0f, 0.0f, 0.0f));
            }
            targetObjectDirty = true;
        }

        //Individual colours.
        GUILayoutOption[] colourWidth = new GUILayoutOption[] { GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.1f) };
        EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.LabelField(position, beginProperty(position, "individualColours", new GUIContent("Individual Colours", "The individual colours to include " +
                "in the palette.")));
        endProperty();
        if (paletteShader.individualColours.Count == 0)
            EditorGUI.LabelField(EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 2, emptyGUILayoutOptions),
                    "There are no individual colours associated with this palette shader component.", noColoursStyle);
        for (int i = 0; i < paletteShader.individualColours.Count; i++) {
            if (i % 4 == 0)
                EditorGUILayout.BeginHorizontal(emptyGUILayoutOptions);

            //Display and allow the user to edit the individual colour.
            EditorGUI.BeginChangeCheck();
            Color individualColour = EditorGUILayout.ColorField(new GUIContent(""), paletteShader.individualColours[i], false, false, false,
                    new ColorPickerHDRConfig(0, 0, 0, 0), colourWidth);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Change Palette Shader Individual Colour");
                paletteShader.individualColours[i] = individualColour;
                targetObjectDirty = true;
            }

            //Delete individual colour button.
            if (GUI.Button(EditorGUILayout.GetControlRect(colourWidth), new GUIContent("X", "Delete this individual colour."), deleteButtonStyle)) {
                Undo.RecordObject(target, "Delete Palette Shader Individual Colour");
                paletteShader.individualColours.RemoveAt(i);
                targetObjectDirty = true;
            }

            //Start a new row, if necessary.
            if (i % 4 == 3 || i == paletteShader.individualColours.Count - 1) {
                if (i == paletteShader.individualColours.Count - 1)
                    for (int j = 0; j < (3 - (i % 4)) * 2; j++)
                        GUILayout.Label("", colourWidth);
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
        }

        //Add an individual colour.
        if (GUI.Button(EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 1.5f, emptyGUILayoutOptions),
                new GUIContent("Add Individual Colour", "Add an individual colour to the palette."))) {
            Undo.RecordObject(target, "Add Palette Shader Individual Colour");
            paletteShader.individualColours.Add(Color.white);
            targetObjectDirty = true;
        }
        
        //Colour ranges.
        GUILayoutOption[] colourRangeTextureWidth = new GUILayoutOption[] { GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.65f) };
        GUILayoutOption[] stepsLabelWidth = new GUILayoutOption[] { GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.115f) };
        GUILayoutOption[] stepsSliderWidth = new GUILayoutOption[] { GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.635f) };
        EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.LabelField(position, beginProperty(position, "colourRanges", new GUIContent("Colour Ranges", "The colour ranges to include in the " +
                "palette.")));
        endProperty();
        if (paletteShader.colourRanges.Count == 0)
            EditorGUI.LabelField(EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 2, emptyGUILayoutOptions),
                    "There are no colour ranges associated with this palette shader component.", noColoursStyle);
        for (int i = 0; i < paletteShader.colourRanges.Count; i++) {
            EditorGUILayout.BeginHorizontal(emptyGUILayoutOptions);

            //Start colour.
            EditorGUI.BeginChangeCheck();
            Color startColour = EditorGUILayout.ColorField(new GUIContent(""), paletteShader.colourRanges[i].startColour, false, false, false,
                    new ColorPickerHDRConfig(0, 0, 0, 0), colourWidth);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Set Palette Shader Colour Range Start Colour");
                paletteShader.colourRanges[i].startColour = startColour;
                targetObjectDirty = true;
            }

            //Draw a texture to give a visual representation of the colour range.
            Rect colourRangeTextureRectangle = EditorGUILayout.GetControlRect(colourRangeTextureWidth);
            Texture2D colourRangeTexture = new Texture2D((int) colourRangeTextureRectangle.width, (int) colourRangeTextureRectangle.height);
            colourRangeTexture.hideFlags = HideFlags.HideAndDontSave;
            for (int j = 0; j < colourRangeTexture.width; j++) {
                float lerpAmount = (float) (int) (((float) j / colourRangeTexture.width) * paletteShader.colourRanges[i].steps) /
                        (paletteShader.colourRanges[i].steps - 1);
                for (int k = 0; k < colourRangeTexture.height; k++)
                    if (j == 0 || j == colourRangeTexture.width - 1 || k == 0 || k == colourRangeTexture.height - 1)
                        colourRangeTexture.SetPixel(j, k, Color.black);
                    else
                        colourRangeTexture.SetPixel(j, k, Color.Lerp(paletteShader.colourRanges[i].startColour, paletteShader.colourRanges[i].endColour,
                                lerpAmount));
            }
            colourRangeTexture.Apply();
            GUI.DrawTexture(colourRangeTextureRectangle, colourRangeTexture);
            DestroyImmediate(colourRangeTexture);

            //End colour.
            EditorGUI.BeginChangeCheck();
            Color endColour = EditorGUILayout.ColorField(new GUIContent(""), paletteShader.colourRanges[i].endColour, false, false, false,
                    new ColorPickerHDRConfig(0, 0, 0, 0), colourWidth);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Set Palette Shader Colour Range End Colour");
                paletteShader.colourRanges[i].endColour = endColour;
                targetObjectDirty = true;
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            //Steps.
            EditorGUILayout.BeginHorizontal(emptyGUILayoutOptions);
            EditorGUILayout.LabelField(new GUIContent("Steps", "The number of distinct steps of colour to display between the start and end colour."),
                    stepsLabelWidth);
            EditorGUI.BeginChangeCheck();
            int steps = EditorGUILayout.IntSlider(paletteShader.colourRanges[i].steps, 2, 255, stepsSliderWidth);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Set Palette Shader Colour Range Steps");
                paletteShader.colourRanges[i].steps = steps;
                targetObjectDirty = true;
            }

            //Delete colour range button.
            if (GUI.Button(EditorGUILayout.GetControlRect(colourWidth), new GUIContent("X", "Delete the colour range."), deleteButtonStyle)) {
                Undo.RecordObject(target, "Delete Palette Shader Colour Range");
                paletteShader.colourRanges.RemoveAt(i);
                targetObjectDirty = true;
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        //Add a colour range.
        if (GUI.Button(EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 1.5f, emptyGUILayoutOptions),
                new GUIContent("Add Colour Range", "Add a new colour range to the palette."))) {
            Undo.RecordObject(target, "Add Palette Shader Colour Range");
            paletteShader.colourRanges.Add(new PaletteShader.ColourRange());
            targetObjectDirty = true;
        }
        EditorGUILayout.GetControlRect(emptyGUILayoutOptions);

        //Brightness.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.BeginChangeCheck();
        float brightness = EditorGUI.Slider(position, beginProperty(position, "brightness", new GUIContent("Brightness", "The brightness of the output " +
                "image, from -1 (full black) through 0 (original image) to 1 (full white).")), paletteShader.brightness, -1, 1);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Palette Shader Brightness");
            paletteShader.brightness = brightness;
            targetObjectDirty = true;
        }
        endProperty();

        //Contrast.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.BeginChangeCheck();
        float contrast = EditorGUI.Slider(position, beginProperty(position, "contrast", new GUIContent("Contrast", "The contrast of the output image, from " +
                "-1 to 1.")), paletteShader.contrast, -1, 1);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Palette Shader Contrast");
            paletteShader.contrast = contrast;
            targetObjectDirty = true;
        }
        endProperty();

        //Pixelation.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.BeginChangeCheck();
        float pixelation = EditorGUI.Slider(position, beginProperty(position, "pixelation", new GUIContent("Pixelation", "The amount of pixelation to apply " +
                "to the output image.")), paletteShader.pixelation, 0, 1);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Palette Shader Pixelation Level");
            paletteShader.pixelation = pixelation;
            targetObjectDirty = true;
        }
        endProperty();

        //Filter mode.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.BeginChangeCheck();
        FilterMode filterMode = (FilterMode) EditorGUI.EnumPopup(position, beginProperty(position, "filterMode", new GUIContent("Filter Mode",
                "The filter mode to apply to the palette texture. Try changing this at runtime to see the difference it makes.")), paletteShader.filterMode);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Palette Shader Filter Mode");
            paletteShader.filterMode = filterMode;
            targetObjectDirty = true;
        }
        endProperty();

        //Quality.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        Rect position90Percent = new Rect(position.xMin, position.yMin, position.width * 0.9f, position.height);
        EditorGUI.BeginChangeCheck();
        PaletteShader.Quality quality = (PaletteShader.Quality) EditorGUI.EnumPopup(position90Percent, beginProperty(position90Percent, "quality",
                new GUIContent("Quality", "The quality of the palette texture. Click the \"?\" button for more information.")), paletteShader.quality);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Palette Shader Quality");
            paletteShader.quality = quality;
            targetObjectDirty = true;
        }
        endProperty();
        Rect position6Percent = new Rect(position.xMin + (position.width * 0.92f), position.yMin, position.width * 0.06f, position.height);
        if (GUI.Button(position6Percent, "?")) {
            PaletteShaderQualityHelp paletteShaderQualityHelp = EditorWindow.GetWindow<PaletteShaderQualityHelp>();
            paletteShaderQualityHelp.minSize = new Vector2(512, 512);
            paletteShaderQualityHelp.titleContent = new GUIContent("Palette Shader - Quality");
        }

        //Time diagnostics.
        position = EditorGUILayout.GetControlRect(emptyGUILayoutOptions);
        EditorGUI.BeginChangeCheck();
        bool timeDiagnostics = EditorGUI.Toggle(position, beginProperty(position, "timeDiagnostics", new GUIContent("Time Diagnostics",
                "Report via the console the amount of time taken to generate the palette shader texture (editor only) when the scene is started. If texture " +
                "generation time is too long, try reducing the quality.")), paletteShader.timeDiagnostics);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Toggle Palette Shader Time Diagnostics");
            paletteShader.timeDiagnostics = timeDiagnostics;
            targetObjectDirty = true;
        }
        endProperty();

        //Set the target palette shader object dirty if required.
        if (targetObjectDirty)
            EditorUtility.SetDirty(target);
    }

    //Begin/end a property (for compatibility with prefabs).
    GUIContent beginProperty(Rect position, string propertyPath, GUIContent label) {
        serializedObject.Update();
        return EditorGUI.BeginProperty(position, label, serializedObject.FindProperty(propertyPath));
    }
    void endProperty() {
        EditorGUI.EndProperty();
        serializedObject.ApplyModifiedProperties();
    }
}