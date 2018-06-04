using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    public const int MAX_ROWS = 23;//判断游戏是否结束
    public const int MAX_COLUMNS = 10;
    private Transform[,] map = new Transform[MAX_COLUMNS,MAX_ROWS];
    public const int NORMAL_ROWS = 20;
    private int score = 0;
    private int highScore = 0;
    private int numbersGame = 0;
    public bool IsData;
    public int Socre { get { return score; } }
    public int HighScore { get { return highScore; } }
    public int NumbersGame { get { return numbersGame; } }

    private void Awake()
    {
        LoadData();
    }
    public bool IsValidMapPosition(Transform t)
    {
        foreach  (Transform child in t)
        {
            if (child.tag != "Block") continue;
             Vector2 Pos=child.position.Round();
             if (IsInsideMap(Pos) == false) return false;
             if (map[(int)Pos.x, (int)Pos.y] != null) return false;
          
        }
        return true;
    }
    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >=0;
    }

    public bool PlaceShape(Transform t) {
        foreach ( Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
      return  CheckMap();

    }
    private bool CheckMap()
    {
        int count = 0;
        for (int i = 0; i < MAX_ROWS; i++)
        {
            bool isFull = CheckIsRowFull(i);
            if (isFull)
            {
                score += 100;
                if (score > highScore)
                {
                    highScore = score;
                }
                count++;
                DeleteRow(i);
                MoveDownRowsAbove(i + 1);
                i--;
            }
        }
        if (count > 0)
        {
            IsData = true;
            return true;
        }
        else
            return false;
    }
    private bool CheckIsRowFull(int Row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, Row] == null) return false;
           
        }
        return true; 
    }
    private void DeleteRow(int Row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            Destroy(map[i,Row].gameObject);
            map[i, Row] = null;
        }
    }
    private void MoveDownRowsAbove(int Row)
    {
        for (int i = Row; i < MAX_ROWS; i++)
        {
            MoveDownRow(i);
        }
    }
    private void MoveDownRow(int Row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i,Row]!=null)
            {
                map[i, Row - 1] = map[i, Row];
                map[i, Row] = null;
                map[i, Row - 1].position += new Vector3(0, -1, 0);
            }
           
        }
    }
    private void LoadData()
    {
        highScore=   PlayerPrefs.GetInt("HighScore", 0);
       numbersGame= PlayerPrefs.GetInt("NumbersGame", 0);
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("NumbersGame", numbersGame);
    }
    public bool IsGameOver()
    {
        for (int i = NORMAL_ROWS; i < MAX_ROWS; i++)
        {
            for (int j = 0; j < MAX_COLUMNS; j++)
            {
                if (map[j, i] != null)
                {
                    numbersGame++;
                    SaveData();
                    return true;
                }
            }
        }
        return false;
    }
    public void ReStart()
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            for (int j = 0; j < MAX_ROWS; j++)
            {
                if (map[i,j]!=null)
                {
                    Destroy(map[i, j].gameObject);
                    map[i, j] = null;
                }
            

            }
        }
        score = 0;
    }
}
