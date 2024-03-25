using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class MazeGenerator3 : MonoBehaviour
{
    public int rows = 10; // Change the number of rows
    public int cols = 10; // Change the number of columns
    public Tile wallTile;
    public Tile passageTile;

    private bool[,] maze;
    private System.Random random;
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        maze = new bool[rows, cols];
        random = new System.Random();

        InitializeMaze();
        StartCoroutine(CarvePassagesCoroutine(random.Next(0, rows), random.Next(0, cols)));
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

    private System.Collections.IEnumerator CarvePassagesCoroutine(int row, int col)
    {
        maze[row, col] = false; // Mark current cell as passage
        DrawMaze(); // Draw the maze after each step

        int[] directions = { -1, 1 }; // Possible directions to move (up or down, left or right)

        Shuffle(directions);

        foreach (int d in directions)
        {
            if (random.Next(0, 2) == 0) // 50% chance to move horizontally
            {
                int nextCol = col + d;

                if (nextCol >= 0 && nextCol < cols && maze[row, nextCol]) // Check if the cell is within bounds and not visited
                {
                    maze[row, (col + nextCol) / 2] = false; // Carve passage between current cell and next cell
                    yield return new WaitForSeconds(0.1f); // Delay for visualization
                    StartCoroutine(CarvePassagesCoroutine(row, nextCol)); // Recursively carve passages from the next cell
                }
            }
            else // 50% chance to move vertically
            {
                int nextRow = row + d;

                if (nextRow >= 0 && nextRow < rows && maze[nextRow, col]) // Check if the cell is within bounds and not visited
                {
                    maze[(row + nextRow) / 2, col] = false; // Carve passage between current cell and next cell
                    yield return new WaitForSeconds(0.1f); // Delay for visualization
                    StartCoroutine(CarvePassagesCoroutine(nextRow, col)); // Recursively carve passages from the next cell
                }
            }
        }
    }

    private void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    private void DrawMaze()
    {
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
