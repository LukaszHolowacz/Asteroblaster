using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    [SerializeField] Animator transitionAnimator;

    public void MainMenuButtonPressed(int sceneId = 0)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }

    public void RepeatButtonPressed(int sceneId = 3)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }
}
