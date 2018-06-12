using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;
        Tile SpawnTile(Vector3 pos)
        {
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            return currentTile;
        }
          void GenerateTiles()
        {
            tiles = new Tile[width, height];
            //Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // NOTE: part 2 goes here
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width * 0.5f,
                                                   height * 0.5f);
                    // Pivot tiles around grid
                    Vector2 pos = new Vector2(x - halfSize.x,
                                              y - halfSize.y);

                    Vector2 offset = new Vector2(.5f, .5f);
                    pos += offset;
                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile using spawn function made earlier
                    Tile tile = SpawnTile(pos);
                    //Attach newly spawned tile to self(transform)
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    tiles[x, y] = tile;
                }
            }
        } 
        void start()
        {
            GenerateTiles();
        }  
          
        public int GetAdjacentMineCount(Tile tile)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y<= 1; y++)
                {
                    // Calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    // Check if the desired x and y is outside bounds
                    if(desiredX < 0 || desiredX >= width ||
                        desiredY < 0 || desiredY >= height)
                    {
                        // Continue to next element in loop
                        continue;
                    }
                    // Select current tile
                    Tile currentTile = tiles[desiredX, desiredY];
                    // Check if that tile is a mine
                    if (currentTile.isMine)
                    {
                        // Increment count by 1
                        count++;
                    }
                }
            }
            // Remember to return the count!
            return count;
        }
        void SelectATile()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin,
                                                 mouseRay.direction);
            if (hit.collider != null)
            {
                Tile hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null)
                {
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    hitTile.Reveal(adjacentMines);
                }
            }
        }
        void FFuncover(int x, int y, bool[,] visited)
        {
            if(x >= 0    && y >= 0 &&
               x < width && y < height)
            {
                if (visited[x, y])
                    return;
                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);
                if(adjacentMines == 0)
                {
                    visited[x, y] = true;
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);
                }
            }
        }
        void UncoverMines(int mineState = 0)
        {
            for (int x = 0; x< width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    if(tile.isMine)
                    {
                        int adjacentMines = GetAdjacentMineCount(tile);
                        tile.Reveal(adjacentMines, mineState);
                    }
                }
            }
        }
     }
}