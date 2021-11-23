using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Voice;
using Facebook.WitAi.Lib;
using Facebook.WitAi;
using TMPro;


public class VoiceManager : MonoBehaviour
{
    [SerializeField]
    private AppVoiceExperience _voiceExperience;
    [SerializeField]
    bool isActive, isActivating, isProcessing;
    [SerializeField]
    float ActivationTime = 2f, TimeoutTime = 5f;

    Coroutine TimeoutCoroutine;
    [SerializeField]
    AssistantFaceControl FaceControl;

    [SerializeField]
    private UnityEvent Fire_Type_Correct, Fire_Type_Incorrect;
    [SerializeField]
    private UnityEvent Extinguisher_Type_Correct, Extinguisher_Type_Incorrect;
    [SerializeField]
    private UnityEvent UnableToUnderstand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateVoice();
        }
    }

    public void ActivateVoice()
    {
        FaceControl.UpdateFace(AssistantState.LOADING);
        if (isActivating || isActive ) return;
        isActivating = true;
        StartCoroutine(ActivateVoiceCoroutine());
    }
    IEnumerator ActivateVoiceCoroutine()
    {
        ActivateWit();
        FaceControl.ShowSubtitle("Activating Voice, Please wait!");
        yield return new WaitForSeconds(ActivationTime);
        isActivating = false;
        isActive = true;

        if (TimeoutCoroutine != null) StopCoroutine(TimeoutCoroutine);
        TimeoutCoroutine = StartCoroutine(Timeout());

        FaceControl.ShowSubtitle("Assistant Listening...");
        FaceControl.UpdateFace(AssistantState.LISTENING);
    }

    public void DeactivateVoice()
    {
        isActivating = false;
        isActive = false;
        isProcessing = false;
        FaceControl.UpdateFace(AssistantState.IDLE);
        _voiceExperience.Deactivate();
    }
    public void ActivateWit()
    {
        _voiceExperience.Activate();
    }

    public void FireTypeIdentify(String fire_type)
    {
        print("Fire");
        FaceControl.ShowSubtitle("I heard Fire is " + fire_type + ". ");

        if (fire_type.Equals("class c"))
        {
            //Correct Answer
            print("Correct Answer");

            Fire_Type_Correct.Invoke();
        }
        else
        {
            //Wrong Answer
            print("Incorrect Answer");

            Fire_Type_Incorrect.Invoke();
        }
        ResponseHandled();
    }

    public void ExtinguisherTypeIdentify(String extinguisher_type)
    {
        print("gg");
        FaceControl.ShowSubtitle("I heard Extinguisher is " + extinguisher_type + " based. ");
        if (extinguisher_type.Equals("carbon di oxide"))
        {
            //Correct Answer
            print("Correct Answer");
            Extinguisher_Type_Correct.Invoke();
        }
        else
        {
            //Wrong Answer
            print("Incorrect Answer");
            Extinguisher_Type_Incorrect.Invoke();
        }
        ResponseHandled();
    }

    public void GetResponse(WitResponseNode response)
    {
        isProcessing = true;
        FaceControl.ShowSubtitle("Processing ...");

        var intent = WitResultUtilities.GetIntentName(response);
        if (intent != "fire_type" && intent != "extinguisher_type")
        {
            FaceControl.ShowSubtitle("Unable to detect. Please repeat.");

            UnableToUnderstand.Invoke();

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
