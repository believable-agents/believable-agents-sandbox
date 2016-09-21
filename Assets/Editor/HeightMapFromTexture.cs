using UnityEditor;
using UnityEngine;

public class HeightMapFromTexture
{
    [MenuItem("Terrain/Heightmap From Texture")]
    void ApplyHeightmap()
    {
        Texture2D heightmap = Selection.activeObject as Texture2D;
        if (heightmap == null)
        {
            EditorUtility.DisplayDialog("No texture selected", "Please select a texture.", "Cancel");
            return;
        }
        Undo.RecordObject(Terrain.activeTerrain.terrainData, "Heightmap From Texture");

        var terrain = Terrain.activeTerrain.terrainData;
        var w = heightmap.width;
        var h = heightmap.height;
        var w2 = terrain.heightmapWidth;
        var heightmapData = terrain.GetHeights(0, 0, w2, w2);
        var mapColors = heightmap.GetPixels();
        var map = new Color[w2 * w2];

        if (w2 != w || h != w)
        {
            // Resize using nearest-neighbor scaling if texture has no filtering
            if (heightmap.filterMode == FilterMode.Point)
            {
                float dx = (float) w / w2;
                float dy = (float) h / w2;
                for (int y = 0; y < w2; y++)
                {
                    if (y % 20 == 0)
                    {
                        EditorUtility.DisplayProgressBar("Resize", "Calculating texture", Mathf.InverseLerp(0.0f, w2, y));
                    }
                    var thisY = (dy * y) * w;
                    var yw = y * w2;
                    for (int x = 0; x < w2; x++)
                    {
                        map[yw + x] = mapColors[(int) (thisY + dx * x)];
                    }
                }
            }
            // Otherwise resize using bilinear filtering
            else {
                var ratioX = 1.0 / (float) w2 / (w - 1);
                var ratioY = 1.0 / (float) w2 / (h - 1);
                for (var y = 0; y < w2; y++)
                {
                    if (y % 20 == 0)
                    {
                        EditorUtility.DisplayProgressBar("Resize", "Calculating texture", Mathf.InverseLerp(0.0f, w2, y));
                    }
                    var yy = Mathf.Floor((float) (y * ratioY));
                    var y1 = yy * w;
                    var y2 = (yy + 1) * w;
                    var yw = y * w2;
                    for (int x = 0; x < w2; x++)
                    {
                        var xx = Mathf.Floor((float) (x * ratioX));

                        var bl = mapColors[(int) (y1 + xx)];
                        var br = mapColors[(int)(y1 + xx + 1)];
                        var tl = mapColors[(int)(y2 + xx)];
                        var tr = mapColors[(int)(y2 + xx + 1)];

                        float xLerp = (float) (x * ratioX - xx);
                        map[yw + x] = Color.Lerp(Color.Lerp(bl, br, xLerp), Color.Lerp(tl, tr, xLerp), (float) (y * ratioY - yy));
                    }
                }
            }
            EditorUtility.ClearProgressBar();
        }
        else {
            // Use original if no resize is needed
            map = mapColors;
        }

        // Assign texture data to heightmap
        for (int y = 0; y < w2; y++)
        {
            for (int x = 0; x < w2; x++)
            {
                heightmapData[y, x] = map[y * w2 + x].grayscale;
            }
        }
        terrain.SetHeights(0, 0, heightmapData);
    }
}

