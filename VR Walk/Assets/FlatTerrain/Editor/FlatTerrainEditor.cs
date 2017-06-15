using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FlatTerrain))]
public class FlatTerrainEditor : Editor
{
    private const string _hardEdgesName = "HARD_EDGES";
    private const string _rimLightingName = "RIM_LIGHTING";
    private readonly Vector2 _defaultTextureScale = new Vector2(15, 15);

    private Terrain _terrain;

    private Vector3 TileScale
    {
        get
        {
            return _terrain.terrainData.size / (_terrain.terrainData.heightmapResolution - 1);
        }
    }

    public override void OnInspectorGUI()
    {
        FlatTerrain controlScript = target as FlatTerrain;
        _terrain = _terrain ?? controlScript.GetComponent<Terrain>();


        if (_terrain.materialType != Terrain.MaterialType.Custom)
        {
            _terrain.materialType = Terrain.MaterialType.Custom;
            _terrain.materialTemplate = controlScript.FlatMaterial;
        }

        EditorGUI.BeginChangeCheck();
        bool isHardEdgesEnabled = _terrain.materialTemplate.IsKeywordEnabled(_hardEdgesName);
        bool hardEdges = EditorGUILayout.Toggle("Hard Texture Edges", isHardEdgesEnabled);
        if (EditorGUI.EndChangeCheck())
        {
            if (hardEdges)
                _terrain.materialTemplate.EnableKeyword(_hardEdgesName);
            else
                _terrain.materialTemplate.DisableKeyword(_hardEdgesName);
        }

        EditorGUI.BeginChangeCheck();
        bool isRimEnabled = _terrain.materialTemplate.IsKeywordEnabled(_rimLightingName);
        bool rim = EditorGUILayout.Toggle("Rim Lighting", isRimEnabled);
        if (EditorGUI.EndChangeCheck())
        {
            if (rim)
                _terrain.materialTemplate.EnableKeyword(_rimLightingName);
            else
                _terrain.materialTemplate.DisableKeyword(_rimLightingName);
        }

        EditorGUI.BeginDisabledGroup(!isRimEnabled);
        EditorGUI.BeginChangeCheck();
        float hurr = EditorGUILayout.Slider("Rim Value", this._terrain.materialTemplate.GetFloat("_RimPower"), 0.01f, 10.0f);
        if (EditorGUI.EndChangeCheck())
            this._terrain.materialTemplate.SetFloat("_RimPower", hurr);
        EditorGUI.EndDisabledGroup();


        var tileScale = new Vector2(this.TileScale.x, this.TileScale.z);
        bool isTiled = true;
        SplatPrototype[] array = this._terrain.terrainData.splatPrototypes;
        for (int index = 0; index < array.Length; index++)
        {
            isTiled = isTiled && (array[index].tileSize == tileScale);
        }

        EditorGUI.BeginChangeCheck();
        isTiled = EditorGUILayout.Toggle("Tile Splat Textures", isTiled);
        if (EditorGUI.EndChangeCheck())
        {
            var scale = _defaultTextureScale;
            if (isTiled)
                scale = tileScale;
            for (int index = 0; index < array.Length; index++)
            {
                array[index].tileSize = scale;
            }

            this._terrain.terrainData.splatPrototypes = array;
            EditorUtility.SetDirty(this._terrain);
        }

    }
}