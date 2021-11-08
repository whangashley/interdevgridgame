using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //create public game object called tilePrefab
    public GameObject tilePrefab;

    //create public sprite array called tileSprites
    public Sprite[] tileSprites;

    //game object array with comma in it called gridTiles
    GameObject[,] gridTiles;

    public int gridWidth;
    public int gridHeight;

    // Start is called before the first frame update
    void Start()
    {
        //create new array gridTiles
        gridTiles = new GameObject[gridWidth, gridHeight];

        //for loop. For i = 0 while i is less than gridWhatever, ++
        for(int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                //run makeTile
                MakeTile(x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTile(int xPos, int yPos)
    {
        //create game object through code? Use Instantiate
        GameObject newTile = Instantiate(tilePrefab);

        //choose random integer from a range of 0 to the end of tileSprites
        int randTile = Random.Range(0, tileSprites.Length);

        //for game object new Tile, render sprite [randomly chosen integer]
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprites[randTile];

        //for gameobj new Tile's position, it will follow the xPos
        newTile.transform.position = new Vector3(transform.position.x + xPos, transform.position.y + yPos, 0);

        //access script TileData like a component...cause it is one. When we put scripts on a game object,
        //(cont) it's a component. We can access the variable we made in the script and set it to something here.
        TileData myData = newTile.GetComponent<TileData>();


        if (randTile == 0)
        {
            myData.tileSpeed = 5;
        }

        else if (randTile == 1)
        {
            myData.tileSpeed = 3;
        }
        else if (randTile == 2)
        {
            myData.tileSpeed = 10;
        }
        else if (randTile == 3)
        {
            myData.tileSpeed = 1;
        }

        //my Data's gridX and gridY will equal xPos and yPos
        myData.gridX = xPos;
        myData.gridY = yPos;

        //new Tile's xPos and yPos are from the gridTiles array
        gridTiles[xPos, yPos] = newTile;
    }
}
