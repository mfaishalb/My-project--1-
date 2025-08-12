using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wire : MonoBehaviour
{
    public Transform startPoint;
    public Transform targetPoint;
    public SpriteRenderer indicator;
    public Color correctColor = Color.green;
    public Color defaultColor = Color.black;
    public float snapDistance = 0.5f;

    private LineRenderer line;
    private Camera cam;
    private bool dragging = false;

    void Start()
    {
        cam = Camera.main;
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, startPoint.position);
        indicator.color = defaultColor;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
        }

        if (Input.GetMouseButtonUp(0) && dragging)
        {
            dragging = false;
            float dist = Vector3.Distance(line.GetPosition(1), targetPoint.position);
            if (dist <= snapDistance)
            {
                line.SetPosition(1, targetPoint.position);
                indicator.color = correctColor;
            }
            else
            {
                line.SetPosition(1, startPoint.position);
                indicator.color = defaultColor;
            }
        }
    }

    void OnMouseDown()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Vector3.Distance(mousePos, startPoint.position) < 0.5f)
        {
            dragging = true;
        }
    }
}
