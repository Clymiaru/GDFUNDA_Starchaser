using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFadeAnimation : MonoBehaviour, IViewAnimation
{
    [Header("Fade In")]
    [SerializeField] private Gradient fadeInGradient;
    [SerializeField] private AnimationCurve fadeInFactor;
    [SerializeField] private float fadeInDuration = 10.0f;

    [Header("Fade Out")]
    [SerializeField] private Gradient fadeOutGradient;
    [SerializeField] private AnimationCurve fadeoutFactor;
    [SerializeField] private float fadeOutDuration = 10.0f;

    private Image image;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_ENTER_START, PerformEntrance);
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_EXIT_START, PerformExit);
    }
    private void Start()
    {
        image = GetComponent<Image>();
        image.color = fadeInGradient.Evaluate(0.0f);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_ENTER_START);
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_EXIT_START);
    }

    private void OnValidate()
    {
        fadeInDuration = Mathf.Max(fadeInDuration, 0.0f);
        fadeOutDuration = Mathf.Max(fadeOutDuration, 0.0f);
    }
    public void PerformEntrance()
    {
        StartCoroutine(FadeInAnimation());
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_COMPLETE);
    }

    public void PerformExit()
    {
        StartCoroutine(FadeOutAnimation());
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_EXIT_COMPLETE);
    }

    private IEnumerator FadeInAnimation()
    {
        float currentTime = 0.0f;
        while (currentTime < fadeInDuration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float t = fadeInFactor.Evaluate(currentTime / fadeInDuration);
            image.color = fadeInGradient.Evaluate(t);
        }
    }

    private IEnumerator FadeOutAnimation()
    {
        float currentTime = 0.0f;
        while (currentTime < fadeOutDuration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float t = fadeoutFactor.Evaluate(currentTime / fadeOutDuration);
            image.color = fadeOutGradient.Evaluate(t);
        }
    }
}
