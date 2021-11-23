using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Voice;
using Facebook.WitAi.Lib;
using Facebook.WitAi;
using TMPro;

public class IntroVoiceManager : MonoBehaviour
{
    [SerializeField]
    private AppVoiceExperience _voiceExperience;
    [SerializeField]
    bool isGestureActive,isActive, isActivating, isProcessing;
    [SerializeField]
    float ActivationTime = 2f, TimeoutTime = 5f;

    Coroutine TimeoutCoroutine;
    [SerializeField]
    AssistantFaceControl FaceControl;

    [SerializeField]
    GameObject Pinch, Next;

    [SerializeField]
    IntroStepControl StepControl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateVoice();
        }
    }

    public void SetGestureActive()
    {
        isGestureActive = true;
        Pinch.SetActive(true);
    }

    public void SetGestureInactive()
    {
        isGestureActive = false;
        Pinch.SetActive(false);
    }
    public void ActivateVoice()
    {
        if (!isGestureActive) return;
        Pinch.SetActive(false);
        FaceControl.UpdateFace(AssistantState.LOADING);
        if (isActivating || isActive) return;
        isActivating = true;
        StartCoroutine(ActivateVoiceCoroutine());
    }
    IEnumerator ActivateVoiceCoroutine()
    {
        _voiceExperience.Activate();
        FaceControl.ShowSubtitle("Activating Voice, Please wait!");
        yield return new WaitForSeconds(ActivationTime);
        isActivating = false;
        isActive = true;

        if (TimeoutCoroutine != null) StopCoroutine(TimeoutCoroutine);
        TimeoutCoroutine = StartCoroutine(Timeout());

        FaceControl.ShowSubtitle("Assistant Listening...");
        Next.SetActive(true);
        FaceControl.UpdateFace(AssistantState.LISTENING);
    }

    public void DeactivateVoice()
    {
        Pinch.SetActive(true);
        Next.SetActive(false);
        isActivating = false;
        isActive = false;
        isProcessing = false;
        FaceControl.UpdateFace(AssistantState.IDLE);
        _voiceExperience.Deactivate();
    }

    public void FireTypeIdentify(String next)
    {
        FaceControl.ShowSubtitle("I heard " + next + ". ");

        if (next.Equals("next"))
        {
            StepControl.Next();
        }
        else
        {
            FaceControl.ShowSubtitle("Unable to detect. Please repeat.");
        }
        ResponseHandled();
    }

    public void GetResponse(WitResponseNode response)
    {
        isProcessing = true;
        FaceControl.ShowSubtitle("Processing ...");

        var intent = WitResultUtilities.GetIntentName(response);
        if (intent != "next")
        {
            FaceControl.ShowSubtitle("Unable to detect. Please repeat.");
            ResponseHandled();
        }
    }

    public void ResponseHandled()
    {
        StartCoroutine(ResponseAfter());
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(TimeoutTime);
        FaceControl.ShowSubtitle();
        DeactivateVoice();
    }

    IEnumerator ResponseAfter()
    {
        yield return new WaitForSeconds(2f);

        isProcessing = false;
        FaceControl.UpdateFace(AssistantState.IDLE);
        DeactivateVoice();
    }
}
