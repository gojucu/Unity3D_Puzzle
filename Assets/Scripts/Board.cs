using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    wait,
    chooseRotater,
    chooseRotation
}

public class Board : MonoBehaviour
{

    private GameObject[] doncekler;
    public GameObject rotaters;
    public List<GameObject> SelectedHexes = new List<GameObject>();

    public GameState currentState = GameState.chooseRotater;
    public int width;
    public int height;
    public int offSet;
    public GameObject tilePrefab;
    public GameObject[] dots;
    //private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    //private FindMatches findMatches;

    // Start is called before the first frame update
    void Start()
    {
        //findMatches = FindObjectOfType<FindMatches>();
        //allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

    private void SetUp()
    {
        //Hexagon's and tiles created
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPositionDot;
                
                if (i% 2 == 0)
                {
                    tempPositionDot = new Vector2((i - (0.25f * i)), j + offSet);
                }
                else
                {
                    tempPositionDot = new Vector2((i-(0.25f*i)), j-0.5f + offSet);
                }
                
                GameObject backgroundTile = Instantiate(tilePrefab, tempPositionDot, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;// oluşturulan nesneleri board un içinde oluşturuyo daha düzenli durması için.
                backgroundTile.name = "(" + i + "," + j + ")";// nesnelerin isimleri

                int dotToUse = Random.Range(0, dots.Length);
                //int maxIterations = 0;
                //while (MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)
                //{
                //    dotToUse = Random.Range(0, dots.Length);
                //    maxIterations++;
                //    Debug.Log(maxIterations);
                //}
                //maxIterations = 0;

                GameObject dot = Instantiate(dots[dotToUse], tempPositionDot, Quaternion.identity);
                dot.GetComponent<Dot>().row = j;
                dot.GetComponent<Dot>().column = i;
                dot.transform.parent = this.transform;
                dot.name = "(" + i + "," + j + ")";
                allDots[i, j] = dot;
            }
        }
        // Döndürmeye yardımcı olucak merkez noktalar oluşturuldu
        for (int i = 0; i < width-1; i++)
        {
            for (int j = 0; j < height-1; j++)
            {
                Vector2 tempPositionRotater1, tempPositionRotater2;
                if (i % 2 == 0)
                {
                    tempPositionRotater1 = new Vector2((0.5f+(0.75f*i)), j + offSet);

                    tempPositionRotater2 = new Vector2(((i*0.75f) + 0.25f), j + 0.5f + offSet);
                    GameObject doncekler = Instantiate(rotaters, tempPositionRotater1, Quaternion.identity);
                    doncekler.name = "(" + i + "," + j + ")";// nesnelerin isimleri
                    SelectedHexes.Add(doncekler);
                    doncekler = Instantiate(rotaters, tempPositionRotater2, Quaternion.identity);

                    doncekler.name = "(" + i + "," + j + ")2";// nesnelerin isimleri
                    SelectedHexes.Add(doncekler);
                }
                else
                {
                    tempPositionRotater1 = new Vector2((0.75f*i) + 0.25f  , j + offSet);
                    tempPositionRotater2 = new Vector2(((i * 0.75f) + 0.5f), j + 0.5f + offSet);

                    GameObject doncekler = Instantiate(rotaters, tempPositionRotater1, Quaternion.identity);
                    doncekler.name = "(" + i + "," + j + ")";// nesnelerin isimleri
                    SelectedHexes.Add(doncekler);
                    doncekler = Instantiate(rotaters, tempPositionRotater2, Quaternion.identity);
                    doncekler.name = "(" + i + "," + j + ")2";// nesnelerin isimleri
                    SelectedHexes.Add(doncekler);
                }

            }
        }
        foreach (var doncekler in SelectedHexes)
        {
            Debug.Log(doncekler.name);
        }
    }
}
