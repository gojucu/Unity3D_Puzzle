using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [Header("Board Variables")]
    public int column;
    public int row;
    public int previousColumn;
    public int previousRow;
    public int targetX;
    public int targetY;
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
        //findMatches = FindObjectOfType<FindMatches>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (board.currentState == GameState.chooseRotater)
        {
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(firstTouchPosition);
        }

    }
    private void OnMouseUp()
    {
        if (board.currentState == GameState.chooseRotater)
        {
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //CalculateAngel();
        }

    }
    //void CalculateAngel()//Açıyı hesaplama hangi yöne dönücek
    //{
    //    if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist)
    //    {
    //        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
    //        //Debug.Log(swipeAngle);
    //        MovePieces();
    //        board.currentState = GameState.wait;
    //    }
    //    else
    //    {
    //        board.currentState = GameState.move;
    //    }

    //}
}
