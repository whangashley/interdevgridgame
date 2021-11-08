using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //create public variable called speed
    public float speed;

    public Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //calling function MoveChar each frame
        MoveChar();
    }

    void MoveChar()
    {
        //creative a new vector callled new pos that holds a position (x and y)
        Vector3 newPos = transform.position;

        //if up arrow is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //y position of newPos has a the value speed multiplied by time Delta time added to it
            newPos.y += speed * Time.deltaTime;
        }
        //else if down arrow is pressed
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //y position of newPos has a the value speed multiplied by time Delta time subtracted from it
            newPos.y -= speed * Time.deltaTime;
        }
        //else if right arrow is pressed
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //x position of newPos has a the value speed multiplied by time Delta time added to it
            newPos.x += speed * Time.deltaTime;
        }
        //else if left arrow is pressed
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //x position of newPos has a the value speed multiplied by time Delta time subtracted from it
            newPos.x -= speed * Time.deltaTime;
        }

        //make it so that the position is updated according to newPos 
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tile")
        {
            //when we overlap with a tile, we trigger it and get that tileSpeed
            speed = collision.GetComponent<TileData>().tileSpeed;
        }

        if (collision.gameObject.tag == "finish")
        {
            SceneManager.LoadScene(2);
        }
    }
}
