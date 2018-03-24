using UnityEngine;

public class NodeFieldGeneration : ISystem
{
    public NodeFieldGenerator cNodeFieldGenerator;
    void Start()
    {
        
        cNodeFieldGenerator.gridOfGameObjects = new GameObject[(int)cNodeFieldGenerator.gridSize.x, (int)cNodeFieldGenerator.gridSize.y, (int)cNodeFieldGenerator.gridSize.z];
        for (int x = 0; x < cNodeFieldGenerator.gridSize.x; x++)
        {
            // cNodeFieldGenerator.gridOfGameObjects[x] = new GameObject[(int)cNodeFieldGenerator.gridSize.y][];
            for (int y = 0; y < cNodeFieldGenerator.gridSize.y; y++)
            {
                // cNodeFieldGenerator.gridOfGameObjects[x][y] = new GameObject[(int)cNodeFieldGenerator.gridSize.z];
                for (int z = 0; z < cNodeFieldGenerator.gridSize.z; z++)
                {
                    GameObject newNode = Instantiate(cNodeFieldGenerator.nodePrefab, gameObject.transform);
                    cNodeFieldGenerator.gridOfGameObjects[x, y, z] = newNode;

                    newNode.name = cNodeFieldGenerator.nodePrefab.name + " [" + x + "," + y + "," + z + "]";

                    Vector3 newNodePosition = new Vector3(x, y, z);
                    newNode.transform.localPosition = newNodePosition * cNodeFieldGenerator.gridSpacing;
                    newNode.GetComponent<BoxCollider>().size = new Vector3(cNodeFieldGenerator.gridSpacing, cNodeFieldGenerator.gridSpacing, cNodeFieldGenerator.gridSpacing);

                    NodeInField cNodeInField = newNode.GetComponent<NodeInField>();
                    cNodeInField.gridCoordinates = newNodePosition;
                    cNodeInField.parentField = gameObject;

                    NodeVector cNodeVector = newNode.GetComponent<NodeVector>();
                    cNodeVector.forceVector = new Vector3(Random.Range(0.01f, 0.02f), Random.Range(0.01f, 0.02f), Random.Range(0.01f, 0.02f));

                }
            }
        }
    }
}
