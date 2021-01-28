using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1;
    public float displayImageDuration = 1;
    public GameObject player;
    private bool isPlayerAtExit, isPlayerCought;
    public CanvasGroup exitBacgroundImageCanvasGroup;
    public CanvasGroup caughtBacgroundImageCanvasGroup;
    private float timer;
    public AudioSource exitAudio, caughtAudio;
    private bool hasAudioPlayed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBacgroundImageCanvasGroup,true, exitAudio);
        }else if (isPlayerCought)
        {
            EndLevel(caughtBacgroundImageCanvasGroup,false, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup canvas,bool doQuit, AudioSource audioSource)
    {
        if(!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        canvas.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            if (doQuit)
            {
                Debug.Log("Fin");
                Application.Quit();
            }else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void CatchPlayer()
    {
        isPlayerCought = true;
    }

}
