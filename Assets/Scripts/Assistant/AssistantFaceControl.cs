using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using DG.Tweening;
using TMPro;
public enum AssistantState
{
    INACTIVE,
    IDLE,
    LOADING,
    ERROR,
    LISTENING
}
public class AssistantFaceControl : MonoBehaviour
{
    [SerializeField]
    GameObject Idle, Loading, Error, Listening;
    [SerializeField]
    Transform LoadingTransform;
    [SerializeField]
    VideoPlayer ListeningVideo;
    [SerializeField]
    Vector3 rot;
    [SerializeField]
    float time = 0.25f;
    [SerializeField]
    TMP_Text SubtitleText;
    [SerializeField]
    ParticleSystem Smoke;
    [SerializeField]
    Transform Toaster, AssistantTransform;
    [SerializeField]
    AssistantPositionControl PositionControl;
    [SerializeField]
    float heightFactor = 20f;

    [SerializeField]
    private UnityEvent ExperienceComplete;
    [SerializeField]
    GameObject FireFail;
    [SerializeField]
    ParticleSystem[] Fire;

    public AssistantState CurrentState = AssistantState.INACTIVE;

    private void Start()
    {
        UpdateFace();
        
    }

    public void UpdateFace(AssistantState NewState = AssistantState.IDLE)
    {
        if (CurrentState == AssistantState.ERROR) return;
        if (NewState == CurrentState) return;

        HandleStateChange(CurrentState, false);
        CurrentState = NewState;
        HandleStateChange(CurrentState, true);
    }

    void HandleStateChange(AssistantState state, bool val)
    {
        switch (state)
        {
            case AssistantState.LOADING:
                LoadingAnimation(val);
                ShowSubtitle("Loading...");
                break;
            case AssistantState.ERROR:
                Error.SetActive(val);
                ShowSubtitle("Error!");
                break;
            case AssistantState.LISTENING:
                ListeningAnimation(val);
                ShowSubtitle("Listening...");
                break;
            default:
                Idle.SetActive(val);
                ShowSubtitle();
                break;
        }
    }

    void ListeningAnimation(bool val)
    {
        if (val)
        {
            Listening.SetActive(val);
            ListeningVideo.Play();
        }
        else
        {
            ListeningVideo.Pause();
            Listening.SetActive(val);
        }
    }

    void LoadingAnimation(bool val)
    {
        if (val)
        {
            Loading.SetActive(val);
            LoadingTransform.DOLocalRotate(rot, time, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
        }
        else
        {
            DOTween.Kill(LoadingTransform);
            Loading.SetActive(val);
        }
    }

    public void ShowSubtitle(string text = "Pinch to Start Listening!")
    {
        SubtitleText.text = text;
    }

    public void ReleaseSmoke(bool val)
    {
        PositionControl.StopHover();
        Debug.Log("Inside release");
        StartCoroutine(SmokeCoroutine());

        if (val) StartCoroutine(IncorrectSmoke());
        else StartCoroutine(CorrectSmoke());
    }

    IEnumerator SmokeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        ShowSubtitle("Moving ...");
        AssistantTransform.DOMove(Toaster.position + Vector3.up * heightFactor, 4f);
        yield return new WaitForSeconds(4f);
        ShowSubtitle("Using Extinguisher ...");
        Smoke.Play();
        yield return new WaitForSeconds(5f);
        ExperienceComplete.Invoke();
    }

    IEnumerator IncorrectSmoke()
    {
        yield return new WaitForSeconds(8f);
        FullFire();
    }

    IEnumerator CorrectSmoke()
    {
        yield return new WaitForSeconds(5f);
        foreach (ParticleSystem s in Fire)
        {
            s.Stop();
        }
        yield return new WaitForSeconds(3f);
        UpdateFace(AssistantState.IDLE);
        Smoke.Stop();
        ShowSubtitle("You Successfully analyzed the fire. Congratulations!");
    }

    public void FullFire()
    {
        Smoke.Stop();
        UpdateFace(AssistantState.ERROR);
        ShowSubtitle("You Failed to analyze!");
        FireFail.SetActive(true);
    }
}
