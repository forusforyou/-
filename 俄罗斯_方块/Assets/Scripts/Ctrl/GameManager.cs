using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isPause=true;
    public Shape[] Shapes;
    public Color[] Colors;
    Shape ShapeBlock = null;
    private Ctrl ctrl;
    private GameObject BlockHolder;



    private void Awake()
    {
        ctrl = GetComponent<Ctrl>();
        BlockHolder = transform.Find("BlockHolder").gameObject;
    }
    private void Update()
    {
        if (isPause) return;
        if (ShapeBlock==null)
        {
            SpawnShape();
        }
   
    }
    public void StartGame()
    {
        isPause = false;//恢复产生砖块
        if (ShapeBlock != null)
            ShapeBlock.Resume();//恢复下落
    }
    public void PauseGame()
    {
        isPause = true;//暂停继续生产砖块
        if (ShapeBlock!=null)
            ShapeBlock.Pause();//暂停下落
        
    }

    
    public void SpawnShape()//生成砖块
    {
        int index = Random.Range(0, Shapes.Length);
        int ColorIndex = Random.Range(0, Colors.Length);
        ShapeBlock = GameObject.Instantiate(Shapes[index]);
        ShapeBlock.transform.parent = BlockHolder.transform;
        ShapeBlock.Init(Colors[ColorIndex],ctrl,this);

    }
    public void FallDown()//下落到不能动了
    {
        ShapeBlock = null;
        if (ctrl.model.IsData)
        {
            ctrl.view.UpdataGameUI(ctrl.model.Socre,ctrl.model.HighScore);
        }
        foreach (Transform t in BlockHolder.transform)
        {
            if (t.childCount<=1)
            {
                Destroy(t.gameObject); 
            }

        }
        if (ctrl.model.IsGameOver())
        {
            PauseGame();
            ctrl.view.ShowGameOverUI(ctrl.model.Socre);

        }
    }
}
