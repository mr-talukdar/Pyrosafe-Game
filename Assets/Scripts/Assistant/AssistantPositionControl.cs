using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AssistantPositionControl : MonoBehaviour
{
    [SerializeField]
    Transform LookAtTarget, MainObject, HoverObject;
    [SerializeField]
    Vector3 pos1, pos2;
    [SerializeField]
    bool isHovering = false, hoverAllowed = true;

    void Update()
    {
        Vector3 lookPos = LookAtTarget.position - MainObject.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
        MainObject.rotation = rotation;

        if (isHovering) return;
        if (!isHovering && hoverAllowed) Hover();

    }

    void Hover()
    {
        isHovering = true;
        StartCoroutine(HoverC());
    }

    IEnumerator HoverC()
    {
        while (hoverAllowed)
        {
            HoverObject.DOLocalMove(pos1, 2f);
            yield return new WaitForSeconds(2f);
            HoverObject.DOLocalMove(pos2, 2f);
            yield return new WaitForSeconds(2f);
        }
    }

    public void StopHover()
    {
        hoverAllowed = false;
        DOTween.Kill(HoverObject);
    }
}
