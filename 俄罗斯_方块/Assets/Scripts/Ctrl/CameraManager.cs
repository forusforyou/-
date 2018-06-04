using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoBehaviour {
    private Camera MainCamera;
	// Use this for initialization
	void Start () {
        MainCamera = Camera.main.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ZoonIN()
    {
        MainCamera.DOOrthoSize(12.29f, 0.5f);
    }
    public void ZonnOUT()
    {
        MainCamera.DOOrthoSize(17.98f, 0.5f);
    }
}
