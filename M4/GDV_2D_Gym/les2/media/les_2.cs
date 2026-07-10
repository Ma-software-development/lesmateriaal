using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EGA : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    // Array that mirrors the tilemap's cells (width x height)
    private TileBase[,] tileArray;
    private BoundsInt cellBounds;
    private int width;
    private int height;

    void Start()
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned.");
            return;
        }

        // Cache bounds and size
        cellBounds = tilemap.cellBounds;
        width = cellBounds.size.x;
        height = cellBounds.size.y;

        Debug.Log($"dus tilemap.size: {tilemap.size} | cellBounds: {cellBounds}");
        Debug.Log("dus:" + cellBounds.position);

        // Create and populate the array so it "connects" to the tilemap
        tileArray = new TileBase[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(cellBounds.x + x, cellBounds.y + y, 0);
                tileArray[x, y] = tilemap.GetTile(pos);
            }
        }
    }

    void Update()
    {
        if (tilemap == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            // converteer de muispositie van schermruimte naar wereldruimte
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f;
            Vector3Int cellPos = tilemap.WorldToCell(worldPosition);

            // geef de posities weer in de console voor debugging
            Debug.Log("mousePosition= " + mousePosition + " worldPosition= " + worldPosition + " Cellposition= " + cellPos);

            // Itereer door de tilemap-cellen binnen de bounds en kleur ze rood als ze overeenkomen met de aangeklikte cel, anders wit
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3Int pos = new Vector3Int(cellBounds.x + x, cellBounds.y + y, 0);

                    tilemap.SetTileFlags(pos, TileFlags.None);
                    if (pos == cellPos)
                        tilemap.SetColor(pos, Color.red);
                    else
                        tilemap.SetColor(pos, Color.white);
                }
            }
        }
    }

    // Helper: get tile from the array using a cell position
    public TileBase GetTileFromArray(Vector3Int cellPosition)
    {
        int ax = cellPosition.x - cellBounds.x;
        int ay = cellPosition.y - cellBounds.y;
        if (tileArray == null) return null;
        if (ax < 0 || ax >= width || ay < 0 || ay >= height) return null;
        return tileArray[ax, ay];
    }

    // Helper: update array and tilemap at a cell position
    public void SetTileAtCell(Vector3Int cellPosition, TileBase tile)
    {
        int ax = cellPosition.x - cellBounds.x;
        int ay = cellPosition.y - cellBounds.y;
        if (tileArray == null) return;
        if (ax < 0 || ax >= width || ay < 0 || ay >= height) return;

        tileArray[ax, ay] = tile;
        tilemap.SetTile(cellPosition, tile);
    }
}
