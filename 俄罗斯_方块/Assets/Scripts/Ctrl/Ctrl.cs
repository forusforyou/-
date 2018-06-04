using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour {

    [HideInInspector]
    public Model model;//对Model层的引用
    [HideInInspector]
    public View view;//对View层的引用
    public CameraManager cameraManager;
    private FSMSystem fsm;
    [HideInInspector]
    public GameManager GameManager;
    [HideInInspector]
    public AudioManager AudioManager;

	void Awake () {
        cameraManager = GetComponent<CameraManager>();
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        GameManager = GetComponent<GameManager>();
        AudioManager = GetComponent<AudioManager>();
     
	}
    private void Start()
    {
        MakeFSM();
    }
    private void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState [] states=GetComponentsInChildren<FSMState>();
        foreach (var state in states)
        {
            fsm.AddState(state,this);
        }
        MenuState s = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(s);
    }

    void Update () {
		
	}
}
