using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    [SerializeField] Animator transitionAnimator;
    [SerializeField] public AudioClip menuBackgroundClip;
    MusicManager musicManager;
    AudioSource audioSource;

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        musicManager.FadeMusic(2.0f, 0, 0, menuBackgroundClip);

    }

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
    public void RepeatLevel(int sceneId = 6)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }
    public void NextLevel(int sceneId = 1)
    {
        transitionAnimator.SetTrigger("CoverTheScreen");
        StartCoroutine(SceneChanger.MoveToScene(sceneId, new Vector3(0, 0, -10), transitionAnimator));
    }
}
