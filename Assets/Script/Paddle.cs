using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    //configuration partamaters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    //cached references
    GameStatus theGameSession;
    Ball theBall;

    // Use this for initialization
    void Start () {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();

    }
	
	// Update is called once per frame
	void Update () {
       
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}
    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
