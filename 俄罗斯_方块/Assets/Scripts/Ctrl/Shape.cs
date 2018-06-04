using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private bool isPause = false;//判断是否需要暂停
    private float timer = 0;//计时器，多少秒运动一格
    private float stepTime = 0.8f;//走一步需要多少时间
    private Ctrl ctrl;
    private GameManager GameManager;
    private Transform Pivot;
    private int Mutiple = 15;
    private bool IsSpeedUp;


    private void Awake()
    {
        Pivot = transform.Find("Pivot");
    }

    private void Update()
    {
        if (isPause) return;//暂停什么也不做
        timer += Time.deltaTime;
        InputController();
        if (timer>stepTime)
        {
            timer = 0;
            Fall();//下落
        }
      
         
    }

   public void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
        if (ctrl.model.IsValidMapPosition(this.transform)==false)//如果位置无效
        {
            pos.y += 1;
            transform.position = pos;
            isPause = true;
            bool islineClear=ctrl.model.PlaceShape(this.transform);
            if (islineClear) ctrl.AudioManager.PlayLineClear();
            GameManager.FallDown();
            return;
        }
        ctrl.AudioManager.PlayDrop();
    }
    public void InputController()
    {
       // if (IsSpeedUp) return;
        float h = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 1;
        }
        if (h!=0)
        {
            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                pos.x -= h;
                transform.position = pos;
                
            }
            else
            {
                ctrl.AudioManager.PlayBalloon();
            
            }       
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(Pivot.position, Vector3.forward, -90);
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                transform.RotateAround(Pivot.position, Vector3.forward, 90);
            }
            else
            {
                ctrl.AudioManager.PlayBalloon();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IsSpeedUp = true;
            stepTime /= Mutiple;
        }
       



    }

    public void Init(Color color,Ctrl ctrl,GameManager GameManager)
    {
        foreach  (Transform t in transform)
        {
            if (t.tag=="Block")
            {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.ctrl = ctrl;
        this.GameManager = GameManager;
    }
    public void Pause()
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
    }

}
