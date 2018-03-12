using UnityEngine;

public class CTeleselectable : MonoBehaviour
{
    public Material defaultMaterial;
    public Material hoverMaterial;
    public bool isHovered;
    public bool hoveringThisFrame;
    public GameObject hoveredBy;
    public bool isSelected;
    public GameObject selectedBy;
}