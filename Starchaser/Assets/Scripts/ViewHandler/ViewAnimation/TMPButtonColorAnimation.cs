using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPButtonColorAnimation : MonoBehaviour, IViewAnimation
{
    [Header("Entrance")]
    [SerializeField] private Gradient entranceGradient;
    [SerializeField] private AnimationCurve entranceTimeFactor;
    [SerializeField] private float entranceDuration = 10.0f;

    [Header("Exit")]
    [SerializeField] private Gradient exitGradient;
    [SerializeField] private AnimationCurve exitTimeFactor;
    [SerializeField] private float extiDuration = 10.0f;

    private Button button;
    private Image buttonImage;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();

        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_ENTER_START, PerformEntrance);
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_EXIT_START, PerformExit);
    }
    private void Start()
    {
        buttonImage.color = entranceGradient.Evaluate(0.0f);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_ENTER_START);
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_EXIT_START);
    }

    private void OnValidate()
    {
        entranceDuration = Mathf.Max(entranceDuration, 0.0f);
        extiDuration = Mathf.Max(extiDuration, 0.0f);
    }
    public void PerformEntrance()
    {
        button.interactable = false;
        StartCoroutine(EntranceAnimation());
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_COMPLETE);
    }

    public void PerformExit()
    {
        button.interactable = false;
        StartCoroutine(ExitAnimation());
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_EXIT_COMPLETE);
    }

    private IEnumerator EntranceAnimation()
    {
        float currentTime = 0.0f;
        while (currentTime < entranceDuration)
        {
            yield return null;
            currentTime += Time.unscaledDeltaTime;
            float t = entranceTimeFactor.Evaluate(currentTime / entranceDuration);
            buttonImage.color = entranceGradient.Evaluate(t);
        }
        button.interactable = true;
    }

    private IEnumerator ExitAnimation()
    {
        float currentTime = 0.0f;
        while (currentTime < extiDuration)
        {
            yield return null;
            currentTime += Time.unscaledDeltaTime;
            float t = exitTimeFactor.Evaluate(currentTime / extiDuration);
            buttonImage.color = exitGradient.Evaluate(t);
        }
    }
}
