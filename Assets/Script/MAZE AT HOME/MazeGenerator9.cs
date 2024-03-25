using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MazeGenerator9 : MonoBehaviour
{
    public int rows = 10; // Change the number of rows
    public int cols = 10; // Change the number of columns
    public Tile wallTile;
    public Tile passageTile;

    private bool[,] maze;
    private System.Random random;

    void Start()
    {
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        maze = new bool[rows, cols];
        random = new System.Random();

        InitializeMaze();
        GenerateUsingWilsonsAlgorithm();
        DrawMaze();
    }

    private void InitializeMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = true; // All cells are walls initially
            }
        }
    }

    private void GenerateUsingWilsonsAlgorithm()
    {
        List<Vector2Int> unvisited = new List<Vector2Int>();

        // Mark all cells as unvisited
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                unvisited.Add(new Vector2Int(i, j));
            }
        }

        // Start with a random cell
        Vector2Int start = unvisited[random.Next(0, unvisited.Count)];
        unvisited.Remove(start);

        // Perform loop-erased random walks until all cells are visited
        while (unvisited.Count > 0)
        {
            Vector2Int current = unvisited[random.Next(0, unvisited.Count)];
            List<Vector2Int> path = new List<Vector2Int>();
            path.Add(current);

            // Check for excessive iterations to prevent infinite loops
            int iterations = 0;
            while (unvisited.Contains(current) && iterations < unvisited.Count * 2)
            {
                Vector2Int next = GetRandomNeighbor(current);
                int index = path.IndexOf(next);

                if (index >= 0)
                {
                    path.RemoveRange(index, path.Count - index);
                }
                else
                {
                    path.Add(next);
                }

                current = next;
                iterations++;
            }

            // Carve the path in the maze
            for (int i = 0; i < path.Count - 1; i++)
            {
                Vector2Int cellA = path[i];
                Vector2Int cellB = path[i + 1];
                int midRow = (cellA.x + cellB.x) / 2;
                int midCol = (cellA.y + cellB.y) / 2;
                maze[midRow, midCol] = false;
            }

            // Remove the visited cells from the unvisited list
            foreach (Vector2Int cell in path)
            {
                unvisited.Remove(cell);
            }
        }
    }

    private Vector2Int GetRandomNeighbor(Vector2Int cell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        // Add neighboring cells that are within the maze bounds
        if (cell.x > 1) neighbors.Add(new Vector2Int(cell.x - 2, cell.y));
        if (cell.x < rows - 2) neighbors.Add(new Vector2Int(cell.x + 2, cell.y));
        if (cell.y > 1) neighbors.Add(new Vector2Int(cell.x, cell.y - 2));
        if (cell.y < cols - 2) neighbors.Add(new Vector2Int(cell.x, cell.y + 2));

        // Return a random neighboring cell
        return neighbors[random.Next(0, neighbors.Count)];
    }

    private void DrawMaze()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        tilemap.ClearAllTiles();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3Int position = new Vector3Int(i, j, 0);
                tilemap.SetTile(position, maze[i, j] ? wallTile : passageTile);
            }
        }
    }
}
