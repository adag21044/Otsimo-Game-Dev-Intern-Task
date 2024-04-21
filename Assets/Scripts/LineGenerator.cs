using UnityEngine;
using System.Collections.Generic;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    private Line activeLine;
    private List<List<Vector2>> savedLines;

    void Update()
    {
        // Check for both mouse and touch input
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            GameObject newLineObject = Instantiate(linePrefab);
            activeLine = newLineObject.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 inputPos = Vector2.zero;

            // Check if using mouse or touch input
            if (Input.touchCount > 0)
            {
                inputPos = Input.GetTouch(0).position;
            }
            else
            {
                inputPos = Input.mousePosition;
            }
            // Convert screen position to world position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(inputPos);
            activeLine.UpdateLine(mousePos);
        }
    }
}