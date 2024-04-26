using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class MazeGenerator6 : MonoBehaviour
{
    public int rows = 10; // Change the number of rows
    public int cols = 10; // Change the number of columns
    public Tile wallTile; // Tile for walls

    private bool[,] maze;
    private Tilemap tilemap;

    //void Start()
    //{
    //    tilemap = GetComponent<Tilemap>();
    //    GenerateMaze();
    //}
    private void OnEnable()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMaze();
    }
    void GenerateMaze()
    {
        maze = new bool[cols, rows]; // Initialize the maze array

        InitializeMaze(); // Fill the maze with walls
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
    

    void InitializePlayer()
    {

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
