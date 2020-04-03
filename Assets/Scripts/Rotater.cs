using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public List<GameObject> SelectedHexes = new List<GameObject>();
    public bool isSelected = false;

    public bool isMatched = false;//default u false ayarlandı

    //private FindMatches findMatches;
    private Board board;
    private GameObject otherDot;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;

    public float swipeAngle = 0;
    public float swipeResist = 1f;//tek tıkta açı 0 olucağı için dönmemesi için min mesafe

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    private void OnMouseDown()
    {
        if (board.currentState == GameState.chooseRotater)
        {
            float shortest;
            float tempShortest=Mathf.Infinity;
            Vector2 currentMousePos;
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (GameObject item in board.SelectedHexes)
            {
                
                shortest = Vector2.Distance(item.GetComponent<Rotater>().transform.position, currentMousePos);
                if (shortest < tempShortest)
                {


                }
            }
            Debug.Log(shortest);
        }
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(firstTouchPosition);


    }
    private void OnMouseUp()
    {
        if (board.currentState == GameState.chooseRotater)
        {
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //CalculateAngel();
        }

    }
}
