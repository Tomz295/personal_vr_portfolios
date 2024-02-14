using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    [SerializeField] GameObject linePrefab;
    GameObject currentLine;
    LineRenderer lineRenderer;

    Vector3 lastPoint;

    [Header("Line Attributes")]
    public Color lineColor = Color.white;
    public float lineWidth = 0.02f;
    public float segmentLength = 0.1f;
    public bool drawing = false;

    public void startDrawing(float segment_length = 0.1f, float line_width = 0.02f, Color? line_color = null)
    {
        segmentLength = segment_length;
        lineWidth = line_width;
        if (line_color != null)
        {
            lineColor = (Color)line_color;
        }
        else
        {
            lineColor = Color.white;
        }
        drawing = true;
    }

    public void stopDrawing()
    {
        drawing = false;
    }

    void createNewLine()
    {
        // Create prefab
        currentLine = Instantiate(linePrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.positionCount = 1;
        setPointAndStartNext();
    }

    void setPointAndStartNext()
    {
        // Add point to line
        lastPoint = transform.position;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, lastPoint);
        lineRenderer.positionCount++;
        updatePoint();
    }

    void updatePoint()
    {
        // Update last point
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }

    void finishCreatingLine()
    {
        setPointAndStartNext();
        generateMeshCollider(currentLine);
        currentLine = null;
    }

    void generateMeshCollider(GameObject obj)
    {
        MeshCollider collider = obj.AddComponent<MeshCollider>();

        Mesh mesh =  new Mesh();
        lineRenderer.BakeMesh(mesh, true);
        collider.sharedMesh = mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drawing)
        {
            if (currentLine == null)
            {
                createNewLine();
            }
            if (Vector3.Distance(lastPoint, transform.position) > segmentLength)
            {
                setPointAndStartNext();
            }
            else
            {
                updatePoint();
            }
        } else
        {
            if (currentLine != null)
            {
                finishCreatingLine();
            }
        }
    }
}
