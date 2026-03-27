using UnityEngine;

public class CTPlaneSliceViewer : MonoBehaviour
{
    public string planeName = "Axial";           // "Axial", "Coronal", or "Sagittal"
    public int totalSlices = 440;
    public KeyCode nextKey = KeyCode.RightArrow;
    public KeyCode prevKey = KeyCode.LeftArrow;
    public Renderer planeRenderer;

    private int currentSlice = 0;
    private const string basePath = "CTSlices";

    void Start()
    {
        if (planeRenderer == null)
            planeRenderer = GetComponent<Renderer>();

        ShowSlice(currentSlice);
    }

    void Update()
    {
        if (Input.GetKeyDown(nextKey))
            ShowSlice(++currentSlice);
        if (Input.GetKeyDown(prevKey))
            ShowSlice(--currentSlice);
    }

    void ShowSlice(int index)
    {
        currentSlice = Mathf.Clamp(index, 0, totalSlices - 1);
        string slicePath = $"{basePath}/{planeName}/image_{currentSlice + 1:00000}";
        Texture2D tex = Resources.Load<Texture2D>(slicePath);
        if (tex)
            planeRenderer.material.mainTexture = tex;
        else
            Debug.LogWarning($"Missing texture: {slicePath}");
    }
}
