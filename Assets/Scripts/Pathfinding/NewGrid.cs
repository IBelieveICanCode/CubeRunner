using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewGrid : MonoBehaviour
{
    public bool displayGridGizmos;
    public LayerMask unwalkableMask;
    [HideInInspector]
    public List<Node> grid = new List<Node>();

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    
    public void CreateGrid(List<Vector3> openTileList)
    {
        nodeDiameter = DungeonMap.tileSize;
        //gridSizeX = Mathf.RoundToInt(map.mapSize.x / nodeDiameter);
        //gridSizeY = Mathf.RoundToInt(map.mapSize.y / nodeDiameter);
        Vector3 worldBottomLeft = transform.position - Vector3.right * map.mapSize.x / 2 - Vector3.forward * map.mapSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft 
                    + Vector3.right * (x * nodeDiameter + nodeDiameter / 2) 
                    + Vector3.forward * (y * nodeDiameter + nodeDiameter / 2);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeDiameter/2, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }
    
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                else if (Mathf.Abs(x) == 1 && Mathf.Abs(y) == 1)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

    /*
    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }
    */
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridSizeX, 1, gridSizeY));
        if (grid != null && displayGridGizmos)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }

}