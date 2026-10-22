using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Interhaptics.Utils;

public class gamemanager : MonoBehaviour
{
    [Header("Buttons")]
    public Button button;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    [Header("Haptic Settings")]
    public EventHapticSource hapticLow1;
    public EventHapticSource hapticLow2;
    public EventHapticSource hapticMid;
    public EventHapticSource hapticHigh1;
    public EventHapticSource hapticHigh2;

    private EventHapticSource[] allHaptics;
    private Coroutine currentRoutine;

    void Start()
    {
        allHaptics = new[] { hapticLow1, hapticLow2, hapticMid, hapticHigh1, hapticHigh2 };

        button.onClick.AddListener(() => PlayHaptic(hapticLow1));
        button1.onClick.AddListener(() => PlayHaptic(hapticLow2));
        button2.onClick.AddListener(() => PlayHaptic(hapticMid));
        button3.onClick.AddListener(() => PlayHaptic(hapticHigh1));
        button4.onClick.AddListener(() => PlayHaptic(hapticHigh2));
    }

    void PlayHaptic(EventHapticSource source)
    {
        // Stop any haptic still running so they don't overlap
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        foreach (var h in allHaptics) h.Stop();

        currentRoutine = StartCoroutine(HapticRoutine(0.08f, source));
    }

    IEnumerator HapticRoutine(float duration, EventHapticSource source)
    {
        source.Play();
        yield return new WaitForSeconds(duration);
        source.Stop();
    }
}