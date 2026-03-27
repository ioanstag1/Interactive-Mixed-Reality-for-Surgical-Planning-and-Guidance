using UnityEngine;
using UnityEngine.UI;

public class SlicePlaneViewer : MonoBehaviour
{
    public string planeName = "Axial";
    public int totalSlices = 440;
    public float axisSpacing = 0.01f;    // distance between slices in meters
    public Renderer planeRenderer;
    public Slider sliceSlider;

    private int currentSlice = 0;
    private const string basePath = "CTSlices";

    void Start()
    {
        if (sliceSlider != null)
        {
            sliceSlider.maxValue = totalSlices - 1;
            sliceSlider.onValueChanged.AddListener(OnSliderChanged);
        }

        ShowSlice(currentSlice);
    }

    void ShowSlice(int index)
    {
        currentSlice = Mathf.Clamp(index, 0, totalSlices - 1);

        string slicePath = $"{basePath}/{planeName}/image_{currentSlice + 1:00000}";
        Texture2D tex = Resources.Load<Texture2D>(slicePath);
        if (tex != null)
            planeRenderer.material.mainTexture = tex;

        // Move the plane based on slice index
        Vector3 pos = transform.localPosition;

        switch (planeName)
        {
            case "Axial":
                pos.y = currentSlice * axisSpacing;
                break;
            case "Coronal":
                pos.z = currentSlice * axisSpacing;
                break;
            case "Sagittal":
                pos.x = currentSlice * axisSpacing;
                break;
        }

        transform.localPosition = pos;
    }

    void OnSliderChanged(float value)
    {
        ShowSlice(Mathf.RoundToInt(value));
    }
}
