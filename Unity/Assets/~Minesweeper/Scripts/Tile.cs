using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        //Functions & Variables go here
        public int x, y;
        public bool isMine = false; //Is the current tile a mine?
        public bool isRevealed = false;  //Has the tile already been revealed?
        [Header("References")]
        public Sprite[] emptySprites; //List of empty sprites i.e, empty, 1, 2, 3,etc...
        public Sprite[] mineSprites; // The mine sprites
        private SpriteRenderer rend; // Reference to sprite renderer

        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            isMine = Random.value < .05f;
        }
        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // Flags the tile as being revealed
            isRevealed = true;
            //Checks if tile is a mine
            if(isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}
