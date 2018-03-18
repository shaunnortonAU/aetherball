using UnityEngine;

public class Teleselectable : IComponent
{
    public Material defaultMaterial;
    public Material hoverMaterial;
    public bool isHovered;
    public bool hoveringThisFrame;
    public GameObject hoveredBy;
    public bool isSelected;
    public GameObject selectedBy;
}