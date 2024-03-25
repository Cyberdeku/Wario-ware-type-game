using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class MazeGenerator7 : MonoBehaviour
{
    public int rows = 10; // Change the number of rows
    public int cols = 10; // Change the number of columns
    public Tile wallTile; // Tile for walls

    private bool[,] maze;
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMaze();
    }

    void GenerateMaze()
    {
        maze = new bool[cols, rows]; // Initialize the maze array

        InitializeMaze(); // Fill the maze with walls
        CreateEntryExit(); // Create entry and exit points
        DrawMaze(); // Draw the maze
    }

    void InitializeMaze()
    {
        // Fill the maze array with walls
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                // Place walls around the maze and leave the interior as false (empty)
                if (i == 0 || j == 0 || i == cols - 1 || j == rows - 1)
                {
                    maze[i, j] = true; // Mark as wall
                }
                else
                {
                    // Randomly fill the interior with walls
                    maze[i, j] = UnityEngine.Random.Range(0, 100) < 30; // Adjust the probability (30%) to your preference
                }
            }
        }
    }

    void CreateEntryExit()
    {
        // Randomly choose entry and exit points on the outer walls
        int entrySide = UnityEngine.Random.Range(0, 4); // 0: top, 1: right, 2: bottom, 3: left
        int exitSide = (entrySide + 2) % 4; // Exit on the opposite side of the entry

        int entryPos, exitPos;
        switch (entrySide)
        {
            case 0: // Top
                entryPos = UnityEngine.Random.Range(1, cols - 1);
                maze[entryPos, 0] = false;
                break;
            case 1: // Right
                entryPos = UnityEngine.Random.Range(1, rows - 1);
                maze[cols - 1, entryPos] = false;
                break;
            case 2: // Bottom
                entryPos = UnityEngine.Random.Range(1, cols - 1);
                maze[entryPos, rows - 1] = false;
                break;
            case 3: // Left
                entryPos = UnityEngine.Random.Range(1, rows - 1);
                maze[0, entryPos] = false;
                break;
        }

        switch (exitSide)
        {
            case 0: // Top
                exitPos = UnityEngine.Random.Range(1, cols - 1);
                maze[exitPos, 0] = false;
                break;
            case 1: // Right
                exitPos = UnityEngine.Random.Range(1, rows - 1);
                maze[cols - 1, exitPos] = false;
                break;
            case 2: // Bottom
                exitPos = UnityEngine.Random.Range(1, cols - 1);
                maze[exitPos, rows - 1] = false;
                break;
            case 3: // Left
                exitPos = UnityEngine.Random.Range(1, rows - 1);
                maze[0, exitPos] = false;
                break;
        }
    }

    void DrawMaze()
    {
        tilemap.ClearAllTiles(); // Clear the tilemap before drawing

        // Draw the maze based on the maze array
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3Int tilePosition = new Vector3Int(i, j, 0);
                TileBase tile = maze[i, j] ? wallTile : null; // Select wall tile if it's a wall, otherwise, null for empty space
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}
