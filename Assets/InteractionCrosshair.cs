using UnityEngine;
using UnityEngine.UI;

public class InteractionCrosshair : MonoBehaviour
{
    public Image crosshair;
    public Color normalColor = Color.white;
    public Color interactColor = Color.yellow;
    public float interactRange = 5f;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            Debug.Log("Raycast hit: " + hit.collider.name + " | Tag: " + hit.collider.tag);

            if (hit.collider.CompareTag("Interactable"))
            {
                crosshair.color = interactColor;
                return;
            }
        }

        crosshair.color = normalColor;
    }
}
