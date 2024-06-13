using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;

    void Start()
    {
        GenerateMazeFromTextFile("maze");
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GenerateMazeFromTextFile("maze");
        }
    }
    void GenerateMazeFromTextFile(string filename)
    {
        string path = Path.Combine(Application.dataPath, "Resources", filename + ".txt");
        if (File.Exists(path))
        {
            string[] allContent = File.ReadAllText(path).Split(new string[] { "---" }, System.StringSplitOptions.RemoveEmptyEntries);
            if (allContent.Length == 0)
            {
                Debug.LogError("No layouts found in file: " + path);
                return;
            }

            // Select a random layout
            string selectedLayout = allContent[Random.Range(0, allContent.Length)];

            // Split the selected layout into lines
            string[] lines = selectedLayout.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

            // Clear the tilemap before generating a new maze
            tilemap.ClearAllTiles();

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    char c = lines[lines.Length - 1 - y][x];
                    Vector3Int position = new Vector3Int(x, y, 0);
                    if (c == 'X')
                    {
                        tilemap.SetTile(position, wallTile);
                    }
                    else if (c == 'O')
                    {
                        
                    }
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }
}