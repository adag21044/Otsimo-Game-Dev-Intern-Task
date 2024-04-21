using UnityEngine;

public class LineRendererToTexture : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int textureWidth = 512;
    public int textureHeight = 512;

    private Texture2D lineTexture;

    void Start()
    {
        RenderLineToTexture();
    }

    public void RenderLineToTexture()
    {
        // Create a render texture
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 0);
        RenderTexture.active = renderTexture;

        // Create a camera to render the LineRenderer
        Camera camera = new GameObject("LineRendererCamera").AddComponent<Camera>();
        camera.orthographic = true;
        camera.orthographicSize = lineRenderer.bounds.extents.y;
        camera.aspect = lineRenderer.bounds.size.x / lineRenderer.bounds.size.y;
        camera.targetTexture = renderTexture;
        camera.transform.position = new Vector3(lineRenderer.transform.position.x, lineRenderer.transform.position.y, -10);
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.clear;

        // Render the LineRenderer to the render texture
        camera.Render();

        // Read pixels from the render texture
        lineTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        lineTexture.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        lineTexture.Apply();

        // Clean up
        RenderTexture.active = null;
        Destroy(camera.gameObject);
        Destroy(renderTexture);

        // Use the lineTexture as desired
    }
}