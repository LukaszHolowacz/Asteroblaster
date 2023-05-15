using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] Animator transitionAnimator;
    public void MainMenuButtonPressed(int sceneId = 0)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }
    public void QuitButtonPressed()
    {
        Application.Quit();
    }
    public void TryAgainButtonPressed(int sceneId = 0)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }
}
