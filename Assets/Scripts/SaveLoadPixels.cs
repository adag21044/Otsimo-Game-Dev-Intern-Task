using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveLoadPixels : MonoBehaviour
{
    [System.Serializable]
    public class LineRendererInfo
    {
        public List<Vector3> positions;
        public float startWidth;
        public float endWidth;
        public bool useWorldSpace;

        public LineRendererInfo(LineRenderer lineRenderer)
        {
            positions = new List<Vector3>();
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                positions.Add(lineRenderer.GetPosition(i));
            }

            startWidth = lineRenderer.startWidth;
            endWidth = lineRenderer.endWidth;
            useWorldSpace = lineRenderer.useWorldSpace;
        }

        public void ApplyToLineRenderer(LineRenderer lineRenderer)
        {
            lineRenderer.positionCount = positions.Count;
            for (int i = 0; i < positions.Count; i++)
            {
                lineRenderer.SetPosition(i, positions[i]);
            }

            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
            lineRenderer.useWorldSpace = useWorldSpace;
        }
    }

    public LineRenderer lineRenderer; // Assign your LineRenderer component here.

    public void SaveLineRendererProperties()
    {
        LineRendererInfo lineRendererInfo = new LineRendererInfo(lineRenderer);

        string json = JsonUtility.ToJson(lineRendererInfo);
        File.WriteAllText(Application.persistentDataPath + "/lineRendererInfo.json", json);
    }

    public void LoadLineRendererProperties()
    {
        string path = Application.persistentDataPath + "/lineRendererInfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LineRendererInfo loadedLineRendererInfo = JsonUtility.FromJson<LineRendererInfo>(json);

            loadedLineRendererInfo.ApplyToLineRenderer(lineRenderer);
        }
        else
        {
            Debug.LogError("Saved LineRenderer properties file not found.");
        }
    }
}
