using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public enum Steps
{
    Step1,
    Step2,
    Step3,
    Step4,
    Step5,
    Step6,
    Step7
}
public class IntroStepControl : MonoBehaviour
{
    [SerializeField]
    AssistantFaceControl FaceControl;
    [SerializeField]
    AudioClip Step1Clip, Step3Clip;
    [SerializeField]
    AudioSource Player;

    [SerializeField]
    CanvasGroup[] CGs;
    [SerializeField]
    IntroVoiceManager VoiceManager;

    public Steps CurrentStep = Steps.Step1;

    bool AudioPlaying = false;
    Coroutine coroutine;
    [SerializeField]float time=5f;
    void Update()
    {
        if (AudioPlaying)
        {
            if (!Player.isPlaying) {
                AudioPlaying = false;
                FaceControl.UpdateFace(AssistantState.IDLE);

                if (CurrentStep == Steps.Step1 || CurrentStep == Steps.Step7) Next();
            }
        }
    }
 

    public void Next()
    {
        switch (CurrentStep)
        {
            case Steps.Step1:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step2;
                FaceControl.UpdateFace(AssistantState.IDLE);
                Step2();
                break;

            case Steps.Step2:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step3;
                FaceControl.UpdateFace(AssistantState.IDLE);
                FadeUnfade(1, false);
                FadeUnfade(4, true);
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = StartCoroutine(GestureActive());
                break;

            case Steps.Step3:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step4;
                FaceControl.UpdateFace(AssistantState.IDLE);
                FadeUnfade(4, false);
                FadeUnfade(5, true);
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = StartCoroutine(GestureActive());
                break;

            case Steps.Step4:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step5;
                FaceControl.UpdateFace(AssistantState.IDLE);
                FadeUnfade(5, false);
                FadeUnfade(6, true);
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = StartCoroutine(GestureActive());
                break;

            case Steps.Step5:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step6;
                FaceControl.UpdateFace(AssistantState.IDLE);
                FadeUnfade(6, false);
                FadeUnfade(7, true);
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = StartCoroutine(GestureActive());
                break;

            case Steps.Step6:
                VoiceManager.SetGestureInactive();
                CurrentStep = Steps.Step7;
                FaceControl.UpdateFace(AssistantState.LISTENING);
                FadeUnfade(7, false);
                AudioPlaying = true;
                Player.clip = Step3Clip;
                Player.Play();
                break;

            case Steps.Step7:
                //Scene Change
                print("SCENE CHANGE!!!!!!!!!!!!!!");
                break;
        }
    }

    public void Step1()
    {
        StartCoroutine(Step1C());
    }

    IEnumerator Step1C()
    {
        
        yield return new WaitForSeconds(time);
        AudioPlaying = true;
        Player.clip = Step1Clip;
        Player.Play();
        FaceControl.UpdateFace(AssistantState.LISTENING);
        FadeUnfade(0, true);
        
    }

    public void Step2()
    {
        StartCoroutine(Step2C());
    }

    IEnumerator Step2C()
    {
        FadeUnfade(0, false);
        FadeUnfade(1, true);

        yield return new WaitForSeconds(2f);
        FadeUnfade(2, false);
        FadeUnfade(3, true);

        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(GestureActive());
    }

    IEnumerator GestureActive()
    {
        yield return new WaitForSeconds(3f);
        VoiceManager.SetGestureActive();
    }

    void FadeUnfade(int index,bool val)
    {
        if (val)
        {
            CGs[index].DOFade(1f, 0.25f);
        }
        else
        {
            CGs[index].DOFade(0f, 0.15f);
        }
    }
}
