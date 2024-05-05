using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationMainHeroMenu : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private List<RectTransform> movePoints = new List<RectTransform>();
    private int currentPointIndex = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.transform.localPosition = movePoints[currentPointIndex].localPosition;
        MoveToNextPointDelayed();
    }

    private void MoveToNextPointDelayed()
    {
        float delay = Random.Range(1f, 1f);
        this.ActionDelayed(delay, MoveToNextPoint);
    }

    private void MoveToNextPoint()
    {
        ++currentPointIndex;
        if (currentPointIndex > movePoints.Count - 1) { currentPointIndex = 0; }
        //Vector3 relative = transform.InverseTransformPoint(movePoints[currentPointIndex].position);
        //float angle = 90f - Mathf.Atan2(movePoints[currentPointIndex].transform.z, dirLookTarget.x) * Mathf.Rad2Deg;
        var subtraction = movePoints[currentPointIndex].position - transform.position;
        var myAngle = Mathf.Atan2(subtraction.y, subtraction.x);
        myAngle *= Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        rect.rotation = Quaternion.Euler(0, 0, myAngle);

        float duration = 3f + Vector3.Magnitude(transform.position - movePoints[currentPointIndex].position) / 500f;
        rect.DOLocalMove(movePoints[currentPointIndex].localPosition, duration).
            OnComplete(MoveToNextPointDelayed);
    }
}
