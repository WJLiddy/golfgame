using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PaletteShader : MonoBehaviour {

    //Enumerated Types.
    enum PixelAreaTest { _1x1x1XPos, _1x1x1XNeg, _1x1x1YPos, _1x1x1YNeg, _1x1x1ZPos, _1x1x1ZNeg, _2x2x1XNegYNeg, _2x2x1XNegYPos, _2x2x1XPosYNeg, _2x2x1XPosYPos,
        _2x1x2XNegZNeg, _2x1x2XNegZPos, _2x1x2XPosZNeg, _2x1x2XPosZPos, _1x2x2YNegZNeg, _1x2x2YNegZPos, _1x2x2YPosZNeg, _1x2x2YPosZPos, _2x2x2XNegYNegZNeg,
        _2x2x2XNegYNegZPos, _2x2x2XNegYPosZNeg, _2x2x2XNegYPosZPos, _2x2x2XPosYNegZNeg, _2x2x2XPosYNegZPos, _2x2x2XPosYPosZNeg, _2x2x2XPosYPosZPos,  _3x3x3 };
    public enum Quality { _4BitsPerRGBChannel, _5BitsPerRGBChannel, _6BitsPerRGBChannel, _7BitsPerRGBChannel, _8BitsPerRGBChannel };

    //Classes.
    [Serializable]
    public class ColourRange {
        public Color startColour = Color.black, endColour = Color.white;
        public int steps = 255;
    }

    //Properties.
    public List<Color> individualColours = new List<Color>();
    public List<ColourRange> colourRanges = new List<ColourRange>();
    public float brightness = 0;
    public float contrast = 0;
    public float pixelation = 0;
    public FilterMode filterMode = FilterMode.Point;
    public Quality quality = Quality._6BitsPerRGBChannel;
    public Material cameraMaterial;
    public bool timeDiagnostics = false;

    //Variables.
    Texture3D colourReferenceTexture;
    bool errors = false;

    //Awake.
    void Awake() {

        //Check that the camera material exists, otherwise flag an error (it must've been cleared somehow, and the user needs to know that Palette Shader won't
        //work in this case).
        if (cameraMaterial == null) {
            errors = true;
            Debug.LogError("The material on this Palette Shader instance has somehow been removed, and is required to allow Palette Shader to work. Please " +
                    "create a new Palette Shader instance to reset the material.");
            return;
        }

        //Display an error if no individual colours and no colour ranges have been specified, meaning no palette can be generated.
        if (individualColours.Count == 0 && colourRanges.Count == 0) {
            errors = true;
            Debug.LogError("No individual colours and no colour ranges have been specified on this Palette Shader component, so no palette can be generated. " +
                    "Please specify at least one individual colour or one colour range.");
            return;
        }

        //Time the texture generation if diagnostics are switched on.
#if UNITY_EDITOR
        System.Diagnostics.Stopwatch stopwatch = null;
        if (timeDiagnostics) {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
        }
#endif

        //Set the texture size from the quality level.
        int textureSize = new int[] { 16, 32, 64, 128, 256 }[(int) quality];

        //Get an array of colours from the individual colours and colour ranges.
        List<Color32> calculatedColoursList = new List<Color32>();
        for (int i = 0; i < individualColours.Count; i++)
            calculatedColoursList.Add(individualColours[i]);
        for (int i = 0; i < colourRanges.Count; i++) {
            Color32 previousColour = Color.black;
            for (int j = 0; j < 256; j++) {
                float lerpAmount = (float) (int) (((float) j / 256) * colourRanges[i].steps) / (colourRanges[i].steps - 1);
                Color32 lerpedColour = Color.Lerp(colourRanges[i].startColour, colourRanges[i].endColour, lerpAmount);
                if (j == 0 || lerpedColour.r != previousColour.r || lerpedColour.g != previousColour.g || lerpedColour.b != previousColour.b)
                    calculatedColoursList.Add(lerpedColour);
                previousColour = lerpedColour;
            }
        }
        Color32[] calculatedColoursArray = calculatedColoursList.ToArray();

        //Create the colour reference texture.
        colourReferenceTexture = new Texture3D(textureSize, textureSize, textureSize, TextureFormat.RGB24, false);
        colourReferenceTexture.hideFlags = HideFlags.HideAndDontSave;
        colourReferenceTexture.wrapMode = TextureWrapMode.Clamp;
        colourReferenceTexture.filterMode = FilterMode.Point;
        colourReferenceTexture.anisoLevel = 0;

        //Initialise the various arrays.
        int pixelCount = textureSize * textureSize * textureSize;
        int[] XYZPosition = new int[pixelCount];
        int[] colourIndexValues = new int[pixelCount];
        PixelAreaTest[] pixelAreaTests = new PixelAreaTest[pixelCount];

        //Set the initial points in the 3D texture to match the specified colours.
        int nextPixelIndex = 0;
        for (int i = 0; i < calculatedColoursArray.Length; i++) {
            int index = (((calculatedColoursArray[i].b * textureSize) / 256) * textureSize * textureSize) +
                    (((calculatedColoursArray[i].g * textureSize) / 256) * textureSize) +
                    ((calculatedColoursArray[i].r * textureSize) / 256);
            if (colourIndexValues[index] == 0) {
                XYZPosition[nextPixelIndex] = index;
                colourIndexValues[index] = i + 1;
                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._3x3x3;
            }
        }

        //Expand each point in the 3D texture outwards until the entire texture is filled.
        int nextPixelToTest = 0;
        int endOfCurrentPixelPass = nextPixelIndex;
        while (true) {
            for (int m = 0; m < 2; m++) {
                for (int i = nextPixelToTest; i < endOfCurrentPixelPass; i++) {
                    if (m == 1 && pixelAreaTests[i] <= PixelAreaTest._1x2x2YPosZPos)
                        continue;
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1XNeg) {
                        if (XYZPosition[i] >= textureSize * textureSize) {
                            if (colourIndexValues[XYZPosition[i] - (textureSize * textureSize)] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] - (textureSize * textureSize);
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1XNeg;
                                colourIndexValues[XYZPosition[i] - (textureSize * textureSize)] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1XPos) {
                        if (XYZPosition[i] < pixelCount - (textureSize * textureSize)) {
                            if (colourIndexValues[XYZPosition[i] + (textureSize * textureSize)] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] + (textureSize * textureSize);
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1XPos;
                                colourIndexValues[XYZPosition[i] + (textureSize * textureSize)] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1YNeg) {
                        if (XYZPosition[i] % (textureSize * textureSize) >= textureSize) {
                            if (colourIndexValues[XYZPosition[i] - textureSize] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] - textureSize;
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1YNeg;
                                colourIndexValues[XYZPosition[i] - textureSize] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1YPos) {
                        if (XYZPosition[i] % (textureSize * textureSize) < (textureSize * textureSize) - textureSize) {
                            if (colourIndexValues[XYZPosition[i] + textureSize] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] + textureSize;
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1YPos;
                                colourIndexValues[XYZPosition[i] + textureSize] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1ZNeg) {
                        if (XYZPosition[i] % textureSize >= 1) {
                            if (colourIndexValues[XYZPosition[i] - 1] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] - 1;
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1ZNeg;
                                colourIndexValues[XYZPosition[i] - 1] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] == PixelAreaTest._1x1x1ZPos) {
                        if (XYZPosition[i] % textureSize < textureSize - 1) {
                            if (colourIndexValues[XYZPosition[i] + 1] == 0) {
                                XYZPosition[nextPixelIndex] = XYZPosition[i] + 1;
                                pixelAreaTests[nextPixelIndex++] = PixelAreaTest._1x1x1ZPos;
                                colourIndexValues[XYZPosition[i] + 1] = colourIndexValues[XYZPosition[i]];
                            }
                        }
                    }
                    else if (pixelAreaTests[i] <= PixelAreaTest._1x2x2YPosZPos) {
                        int X = XYZPosition[i] / (textureSize * textureSize), Y = (XYZPosition[i] / textureSize) % textureSize,
                                Z = XYZPosition[i] % textureSize;
                        bool xUnit = pixelAreaTests[i] == PixelAreaTest._1x2x2YNegZNeg || pixelAreaTests[i] == PixelAreaTest._1x2x2YNegZPos ||
                                pixelAreaTests[i] == PixelAreaTest._1x2x2YPosZNeg || pixelAreaTests[i] == PixelAreaTest._1x2x2YPosZPos;
                        bool yUnit = pixelAreaTests[i] == PixelAreaTest._2x1x2XNegZNeg || pixelAreaTests[i] == PixelAreaTest._2x1x2XNegZPos ||
                                pixelAreaTests[i] == PixelAreaTest._2x1x2XPosZNeg || pixelAreaTests[i] == PixelAreaTest._2x1x2XPosZPos;
                        bool zUnit = !xUnit && !yUnit;
                        bool xPositive = !xUnit && (pixelAreaTests[i] == PixelAreaTest._2x2x1XPosYNeg || pixelAreaTests[i] == PixelAreaTest._2x2x1XPosYPos ||
                                pixelAreaTests[i] == PixelAreaTest._2x1x2XPosZNeg || pixelAreaTests[i] == PixelAreaTest._2x1x2XPosZPos);
                        bool yPositive = !yUnit && (pixelAreaTests[i] == PixelAreaTest._2x2x1XNegYPos || pixelAreaTests[i] == PixelAreaTest._2x2x1XPosYPos ||
                                pixelAreaTests[i] == PixelAreaTest._1x2x2YPosZNeg || pixelAreaTests[i] == PixelAreaTest._1x2x2YPosZPos);
                        bool zPositive = !zUnit && (pixelAreaTests[i] == PixelAreaTest._2x1x2XNegZPos || pixelAreaTests[i] == PixelAreaTest._2x1x2XPosZPos ||
                                pixelAreaTests[i] == PixelAreaTest._1x2x2YNegZPos || pixelAreaTests[i] == PixelAreaTest._1x2x2YPosZPos);
                        for (int j = xUnit || xPositive || X == 0 ? 0 : -1; j <= (xUnit || !xPositive || X == textureSize - 1 ? 0 : 1); j++)
                            for (int k = yUnit || yPositive || Y == 0 ? 0 : -1; k <= (yUnit || !yPositive || Y == textureSize - 1 ? 0 : 1); k++)
                                for (int l = zUnit || zPositive || Z == 0 ? 0 : -1; l <= (zUnit || !zPositive || Z == textureSize - 1 ? 0 : 1); l++) {
                                    if (j == 0 && k == 0 && l == 0)
                                        continue;
                                    int gridIndexXYZ = ((X + j) * textureSize * textureSize) + ((Y + k) * textureSize) + Z + l;
                                    if (colourIndexValues[gridIndexXYZ] == 0) {
                                        XYZPosition[nextPixelIndex] = gridIndexXYZ;
                                        if ((j != 0 && k != 0) || (j != 0 && l != 0) || (k != 0 && l != 0))
                                            pixelAreaTests[nextPixelIndex] = pixelAreaTests[i];
                                        else if (j == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XNeg;
                                        else if (j == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XPos;
                                        else if (k == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YNeg;
                                        else if (k == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YPos;
                                        else if (l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZNeg;
                                        else if (l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZPos;
                                        nextPixelIndex++;
                                        colourIndexValues[gridIndexXYZ] = colourIndexValues[XYZPosition[i]];
                                    }
                                }
                    }
                    else if (pixelAreaTests[i] <= PixelAreaTest._2x2x2XPosYPosZPos) {
                        int X = XYZPosition[i] / (textureSize * textureSize), Y = (XYZPosition[i] / textureSize) % textureSize,
                                Z = XYZPosition[i] % textureSize;
                        bool xPositive = pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYNegZNeg || pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYNegZPos ||
                                pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYPosZNeg || pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYPosZPos;
                        bool yPositive = pixelAreaTests[i] == PixelAreaTest._2x2x2XNegYPosZNeg || pixelAreaTests[i] == PixelAreaTest._2x2x2XNegYPosZPos ||
                                pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYPosZNeg || pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYPosZPos;
                        bool zPositive = pixelAreaTests[i] == PixelAreaTest._2x2x2XNegYNegZPos || pixelAreaTests[i] == PixelAreaTest._2x2x2XNegYPosZPos ||
                                pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYNegZPos || pixelAreaTests[i] == PixelAreaTest._2x2x2XPosYPosZPos;
                        for (int j = xPositive || X == 0 ? m : -1; j <= (!xPositive || X == textureSize - 1 ? -m : 1); j++)
                            for (int k = yPositive || Y == 0 ? m : -1; k <= (!yPositive || Y == textureSize - 1 ? -m : 1); k++)
                                for (int l = zPositive || Z == 0 ? m : -1; l <= (!zPositive || Z == textureSize - 1 ? -m : 1); l++) {
                                    if (m == 0 && ((j == 0 && k == 0 && l == 0) || (j != 0 && k != 0 && l != 0)))
                                        continue;
                                    int gridIndexXYZ = ((X + j) * textureSize * textureSize) + ((Y + k) * textureSize) + Z + l;
                                    if (colourIndexValues[gridIndexXYZ] == 0) {
                                        XYZPosition[nextPixelIndex] = gridIndexXYZ;
                                        if (m == 1)
                                            pixelAreaTests[nextPixelIndex] = pixelAreaTests[i];
                                        else if (j == -1 && k == -1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XNegYNeg;
                                        else if (j == -1 && k == 1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XNegYPos;
                                        else if (j == 1 && k == -1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XPosYNeg;
                                        else if (j == 1 && k == 1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XPosYPos;
                                        else if (j == -1 && k == 0 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XNegZNeg;
                                        else if (j == -1 && k == 0 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XNegZPos;
                                        else if (j == 1 && k == 0 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XPosZNeg;
                                        else if (j == 1 && k == 0 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XPosZPos;
                                        else if (j == 0 && k == -1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YNegZNeg;
                                        else if (j == 0 && k == -1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YNegZPos;
                                        else if (j == 0 && k == 1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YPosZNeg;
                                        else if (j == 0 && k == 1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YPosZPos;
                                        else if (j == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XNeg;
                                        else if (j == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XPos;
                                        else if (k == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YNeg;
                                        else if (k == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YPos;
                                        else if (l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZNeg;
                                        else if (l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZPos;
                                        nextPixelIndex++;
                                        colourIndexValues[gridIndexXYZ] = colourIndexValues[XYZPosition[i]];
                                    }
                                }
                    }
                    else {
                        int X = XYZPosition[i] / (textureSize * textureSize), Y = (XYZPosition[i] / textureSize) % textureSize,
                                Z = XYZPosition[i] % textureSize;
                        for (int j = X == 0 ? 0 : -1; j <= (X == textureSize - 1 ? 0 : 1); j++)
                            for (int k = Y == 0 ? 0 : -1; k <= (Y == textureSize - 1 ? 0 : 1); k++)
                                for (int l = Z == 0 ? 0 : -1; l <= (Z == textureSize - 1 ? 0 : 1); l++) {
                                    bool corner = j != 0 && k != 0 && l != 0;
                                    if ((j == 0 && k == 0 && l == 0) || (m == 0 && corner) || (m == 1 && !corner))
                                        continue;
                                    int gridIndexXYZ = ((X + j) * (textureSize * textureSize)) + ((Y + k) * textureSize) + Z + l;
                                    if (colourIndexValues[gridIndexXYZ] == 0) {
                                        XYZPosition[nextPixelIndex] = gridIndexXYZ;
                                        if (j == -1 && k == 0 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XNeg;
                                        else if (j == 1 && k == 0 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1XPos;
                                        else if (j == 0 && k == -1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YNeg;
                                        else if (j == 0 && k == 1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1YPos;
                                        else if (j == 0 && k == 0 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZNeg;
                                        else if (j == 0 && k == 0 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x1x1ZPos;
                                        else if (j == -1 && k == -1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XNegYNeg;
                                        else if (j == -1 && k == 1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XNegYPos;
                                        else if (j == 1 && k == -1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XPosYNeg;
                                        else if (j == 1 && k == 1 && l == 0)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x1XPosYPos;
                                        else if (j == -1 && k == 0 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XNegZNeg;
                                        else if (j == -1 && k == 0 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XNegZPos;
                                        else if (j == 1 && k == 0 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XPosZNeg;
                                        else if (j == 1 && k == 0 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x1x2XPosZPos;
                                        else if (j == 0 && k == -1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YNegZNeg;
                                        else if (j == 0 && k == -1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YNegZPos;
                                        else if (j == 0 && k == 1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YPosZNeg;
                                        else if (j == 0 && k == 1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._1x2x2YPosZPos;
                                        else if (j == -1 && k == -1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XNegYNegZNeg;
                                        else if (j == -1 && k == -1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XNegYNegZPos;
                                        else if (j == -1 && k == 1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XNegYPosZNeg;
                                        else if (j == -1 && k == 1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XNegYPosZPos;
                                        else if (j == 1 && k == -1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XPosYNegZNeg;
                                        else if (j == 1 && k == -1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XPosYNegZPos;
                                        else if (j == 1 && k == 1 && l == -1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XPosYPosZNeg;
                                        else if (j == 1 && k == 1 && l == 1)
                                            pixelAreaTests[nextPixelIndex] = PixelAreaTest._2x2x2XPosYPosZPos;
                                        nextPixelIndex++;
                                        colourIndexValues[gridIndexXYZ] = colourIndexValues[XYZPosition[i]];
                                    }
                                }
                    }
                }
            }
            if (nextPixelIndex == pixelCount)
                break;
            nextPixelToTest = endOfCurrentPixelPass;
            endOfCurrentPixelPass = nextPixelIndex;
        }

        //Set the pixel colours and apply to the texture.
        Color32[] pixelColours = new Color32[pixelCount];
        for (int i = 0; i < pixelCount; i++)
            pixelColours[i] = calculatedColoursArray[colourIndexValues[i] - 1];
        colourReferenceTexture.SetPixels32(pixelColours);
        colourReferenceTexture.Apply(false);

        //Report how long the algorithm took, if diagnostics are enabled.
#if UNITY_EDITOR
        if (timeDiagnostics) {
            stopwatch.Stop();
            Debug.Log("Palette shader texture generation time: " + ((float) stopwatch.ElapsedMilliseconds / 1000) + " seconds");
        }
#endif
    }

    //Pass the camera image through the shader before rendering it to screen.
    void OnRenderImage(RenderTexture sourceRenderTexture, RenderTexture destinationRenderTexture) {
        if (!errors) {
            cameraMaterial.SetTexture("colourReferenceTexture", colourReferenceTexture);
            colourReferenceTexture.filterMode = filterMode;
            cameraMaterial.SetFloat("brightness", brightness);
            cameraMaterial.SetFloat("contrast", contrast);
            cameraMaterial.SetFloat("pixelation", pixelation);
            Graphics.Blit(sourceRenderTexture, destinationRenderTexture, cameraMaterial);
        }
    }

    //Called when the Monobehaviour is destroyed - destroy the colour reference texture.
    void OnDestroy() {
        DestroyImmediate(colourReferenceTexture);
    }
}
