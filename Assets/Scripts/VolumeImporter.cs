using UnityEngine;
using System.IO;
using UnityEditor; // Required to save the texture asset (this only works in the Unity Editor)
using System;

public class VolumeImporter : MonoBehaviour
{
    public string rawFilePath = "Assets/VolumeData/ct_volume.raw"; // Path to your raw file
    public string jsonFilePath = "Assets/VolumeData/ct_volume.json"; // Path to your JSON metadata

    public int width, height, depth;
    public Texture3D volumeTexture;

    void Start()
    {
        // Load volume metadata (JSON file)
        string jsonText = File.ReadAllText(jsonFilePath);
        VolumeMetadata metadata = JsonUtility.FromJson<VolumeMetadata>(jsonText);

        width = metadata.width;
        height = metadata.height;
        depth = metadata.depth;

        // Load raw data (volume)
        byte[] rawData = File.ReadAllBytes(rawFilePath);
        if (rawData.Length != width * height * depth)
        {
            Debug.LogError("RAW file size does not match the expected dimensions.");
            return;
        }

        // Create and fill the 3D texture
        volumeTexture = new Texture3D(width, height, depth, TextureFormat.R8, false);
        volumeTexture.wrapMode = TextureWrapMode.Repeat;
        volumeTexture.filterMode = FilterMode.Point;

        Color[] volumeColors = new Color[rawData.Length];
        for (int i = 0; i < rawData.Length; i++)
        {
            volumeColors[i] = new Color(rawData[i] / 255f, rawData[i] / 255f, rawData[i] / 255f); // Grayscale color mapping
        }

        volumeTexture.SetPixels(volumeColors);
        volumeTexture.Apply();

        // OPTIONAL: Save the texture as an asset for easier manual use in Unity (this will only work in Unity Editor)
        #if UNITY_EDITOR
        string texturePath = "Assets/VolumeData/VolumeTexture3D.asset";
        AssetDatabase.CreateAsset(volumeTexture, texturePath); // Create the asset in Unity's Asset Database
        AssetDatabase.SaveAssets(); // Save the asset
        #endif

        // Apply the volume texture to a material or use it in your shader
        GetComponent<Renderer>().material.SetTexture("_VolumeTex", volumeTexture);
    }

    [Serializable]
    public class VolumeMetadata
    {
        public int width;
        public int height;
        public int depth;
    }
}
