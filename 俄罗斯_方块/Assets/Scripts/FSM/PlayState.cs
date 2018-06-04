using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }
    public override void DoBeforeEntering()
    {   
        ctrl.view.ShowGameUI(ctrl.model.Socre,ctrl.model.HighScore);
        ctrl.cameraManager.ZoonIN();
        ctrl.GameManager.StartGame();
    }
    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGameUI();
        ctrl.view.ShowRestartButon();
        ctrl.GameManager.PauseGame();
       
    }
    public void OnPauseButtonClick()
    {
        ctrl.AudioManager.PlayCursor();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }
    public void OnReStartButtonClick()
    {
        ctrl.view.HideGameOverUI();
        ctrl.model.ReStart();
        ctrl.GameManager.StartGame();
        ctrl.view.UpdataGameUI(0,ctrl.model.HighScore);
        
    }
}
