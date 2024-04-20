using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    private Line activeLine;
    

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLineObject = Instantiate(linePrefab);
            activeLine = newLineObject.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SaveActiveLine();
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    private void SaveActiveLine()
    {
        if (activeLine != null)
        {
            List<Vector2> points = activeLine.GetPoints();
            
            
        }
    }

    

    
}