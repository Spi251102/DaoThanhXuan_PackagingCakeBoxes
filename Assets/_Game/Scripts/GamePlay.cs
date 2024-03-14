using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDown;
    private float time;
    public List<Character> charaterList = new();
    public List<Character> cellList = new();
    
    public int boardSize = 3;
    public Character[,] board;

    private int cakeRow;
    private int cakeColumn;
    private int giftBoxRow;
    private int giftBoxColumn;
    // Start is called before the first frame update
    /*void Start()
    {
        time = GameManager.instance.countDown;
        InitializeGame();
        Debug.Log(board.Length);
        CreateCharacter();
    }*/

    private void OnEnable()
    {
        time = GameManager.instance.countDown;
        InitializeGame();
        Debug.Log(board.Length);
        CreateCharacter();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveCharacter(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveCharacter(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveCharacter(1 , 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCharacter(0, 1);
        }

        time  -= Time.deltaTime;
        countDown.text = "00:"  + ((int)time).ToString();
        Debug.Log(time);
    }

    private void InitializeGame()
    {
        board = new Character[boardSize, boardSize];

        for (int row = 0; row < boardSize; row++)
        {
            for (int column = 0; column < boardSize; column++)
            {
                board[row, column] = new Character();
            }
        }

        for (int i = 0; i < cellList.Count; i++)
        {
            int row = i / boardSize;
            int column = i % boardSize;
            board[row, column] = cellList[i];
        }
    }
    private void CreateCharacter()
    {
        for (int row = 0; row < boardSize; row++)
        {
            for (int column = 0; column < boardSize; column++)
            {
                foreach (Character c in charaterList)
                {
                    if (board[row, column].type == c.type)
                    {
                        Character character = Instantiate(c, board[row, column].transform.position, Quaternion.identity, board[row, column].transform);                     
                        //Debug.Log("Create");
                        if (board[row, column].type == GameManager.TypeCharacter.CAKE)
                        {
                            cakeColumn = column;
                            cakeRow = row;
                        }
                        if (board[row, column].type == GameManager.TypeCharacter.GIFTBOX)
                        {
                            giftBoxColumn = column;
                            giftBoxRow = row;
                        }
                    }
                }
            }
        }
        /*for (int i = 0; i < cellList.Count; i++)
        {
            foreach (Character c in charaterList)
            {
                if (cellList[i].type == c.type)
                {
                    Character character =  Instantiate(c, cellList[i].transform.position, Quaternion.identity, cellList[i].transform);
                    characters.Add(character);  
                    Debug.Log("Create");
                }
            }
                  
        }*/
    }

    private void MoveCharacter(int rowOffset, int columnOffset)
    {
        /*for (int row = 0; row < boardSize; row++)
        {
            for (int column = 0; column < boardSize; column++)
            {
                if (board[row, column].type == GameManager.TypeCharacter.CAKE || board[row, column].type == GameManager.TypeCharacter.GIFTBOX)
                {
                    if(IsValidMove(row + rowOffset, column + columnOffset))
                    {
                        SwapGameObjects(board[row, column], board[row + rowOffset, column + columnOffset]);

                    }    
                }    
            }
        }*/
        if (board[cakeRow, cakeColumn].type == GameManager.TypeCharacter.CAKE )
        {
            /*if(board[cakeRow + rowOffset, cakeColumn + columnOffset].type == GameManager.TypeCharacter.GIFTBOX && cakeColumn == giftBoxColumn + 1 && cakeRow == giftBoxRow)
            {

            }   */ 
            while(IsValidMove(cakeRow + rowOffset, cakeColumn + columnOffset))
            {
                SwapGameObjects(board[cakeRow, cakeColumn], board[cakeRow + rowOffset, cakeColumn + columnOffset]);
                cakeRow += rowOffset;
                cakeColumn += columnOffset;
                Debug.Log("Toa do Cake: " + cakeRow + " " + cakeColumn);
            }    
            /*if (IsValidMove(cakeRow + rowOffset, cakeColumn + columnOffset))
            {
                SwapGameObjects(board[cakeRow, cakeColumn], board[cakeRow + rowOffset, cakeColumn + columnOffset]);
                cakeRow +=  rowOffset;
                cakeColumn += columnOffset;
                Debug.Log("Toa do Cake: " + cakeRow + " " + cakeColumn);
            }*/
        }
        if (board[giftBoxRow, giftBoxColumn].type == GameManager.TypeCharacter.GIFTBOX)
        {
            while(IsValidMove(giftBoxRow + rowOffset, giftBoxColumn + columnOffset) )
            {
                SwapGameObjects(board[giftBoxRow, giftBoxColumn], board[giftBoxRow + rowOffset, giftBoxColumn + columnOffset]);
                giftBoxRow += rowOffset;
                giftBoxColumn += columnOffset;
                Debug.Log("Toa do Gift: " + giftBoxRow + " " + giftBoxColumn);
            }
            /*if (IsValidMove(giftBoxRow + rowOffset, giftBoxColumn + columnOffset))
            {
                SwapGameObjects(board[giftBoxRow, giftBoxColumn], board[giftBoxRow + rowOffset, giftBoxColumn + columnOffset]);
                giftBoxRow += rowOffset;
                giftBoxColumn += columnOffset;
                Debug.Log("Toa do Gift: " + giftBoxRow + " " + giftBoxColumn);
            }*/
        }
    }

    public void SwapGameObjects(Character obj1, Character obj2)
    {
        Transform child1;
        Transform child2;
        Vector3 tempPosition;
        Transform parent1;
        GameManager.TypeCharacter tmp;
        if ((obj1.type == GameManager.TypeCharacter.CAKE && obj2.type == GameManager.TypeCharacter.GIFTBOX))
        {
            MergeCell(obj1);
            return;
        }
        else if((obj1.type == GameManager.TypeCharacter.GIFTBOX && obj2.type == GameManager.TypeCharacter.CAKE))
        {
            child1 = obj1.transform.GetChild(0);
            child2 = obj2.transform.GetChild(0);


            tempPosition = child1.localPosition;
            child1.localPosition = child2.localPosition;
            child2.localPosition = tempPosition;


            parent1 = child1.parent;
            child1.SetParent(child2.parent, false);
            child2.SetParent(parent1, false);

            tmp = obj1.type;
            obj1.type = obj2.type;
            obj2.type = tmp;

            MergeCell(obj2);
            return;
        }    
        child1 = obj1.transform.GetChild(0);
        child2 = obj2.transform.GetChild(0);

       
        tempPosition = child1.localPosition;
        child1.localPosition = child2.localPosition;
        child2.localPosition = tempPosition;

        parent1 = child1.parent;
        child1.SetParent(child2.parent, false);
        child2.SetParent(parent1, false);

        
        tmp = obj1.type;
        obj1.type = obj2.type;
        obj2.type = tmp;
    }

    private bool IsValidMove(int row, int column)
    {
        
        if (row < 0 || row >= boardSize || column < 0 || column >= boardSize)
        {
            return false; 
        }

        
        if (board[row, column].type == GameManager.TypeCharacter.CANDY)
        {
            return false; 
        }
        if (board[row, column].type == GameManager.TypeCharacter.GIFTBOX)
        {
            if(CanWin())
            {
                Debug.Log("CanWin");
                return true;
            }
            return false; 
        }
        if(board[row, column].type == GameManager.TypeCharacter.CAKE)
        {
            if (CanWin())
            {
                Debug.Log("CanWin");
                return true;
            }
            return false; 
        }
        return true;
    }

    private bool CanWin()
    {
        if (cakeRow == giftBoxRow - 1 && cakeColumn == giftBoxColumn)
        {
            Debug.Log("cakeRow = " + cakeRow + "cakeCol = " + cakeColumn);
            Debug.Log("giftBoxRow = " + giftBoxRow + "giftBoxColumn = " + giftBoxColumn);
            return true;
        }
        return false;
    }    

    private void MergeCell(Character cake)
    {
        
        cake.gameObject.SetActive(false);
        GameManager.instance.GameCompleted();
    }
}
