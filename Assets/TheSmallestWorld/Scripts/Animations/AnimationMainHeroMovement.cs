using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMainHeroMovement : MonoBehaviour
{
    [SerializeField] private List<Sprite> moveSequense;

    private SpriteRenderer spriteRenderer;

    private IEnumerator stepsAnimationSequence;

    private const float AnimationTickTime = .1f;
    private WaitForSeconds waitTick = new WaitForSeconds(AnimationTickTime);

    private int stepSequenceIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        stepSequenceIndex = 0;
    }

    public void StartMovement()
    {
        if (stepsAnimationSequence == null)
        {
            stepsAnimationSequence = StepsAnimationSequence();
        }
        StartCoroutine(stepsAnimationSequence);
    }

    public void StopMovement()
    {
        if (stepsAnimationSequence != null)
        {
            StopCoroutine(stepsAnimationSequence);
            spriteRenderer.sprite = moveSequense[0];
        }
    }

    private IEnumerator StepsAnimationSequence()
    {
        while (true)
        {
            spriteRenderer.sprite = moveSequense[stepSequenceIndex++];
            if (stepSequenceIndex > moveSequense.Count - 1)
            {
                stepSequenceIndex = 0;
            }
            yield return waitTick;
        }
    }
}
