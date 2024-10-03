using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Events for button hold and release
    [System.Serializable]
    public class HoldEvent : UnityEvent { }
    public HoldEvent OnButtonHold;
    public UnityEvent OnButtonRelease;

    // Flag to check if the button is being held
    public bool isHolding { get; private set; }

    // The time (in seconds) the button needs to be held to trigger OnButtonHold continuously
    public float holdThreshold = 1.0f;

    private float holdStartTime;

    // Called when the button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        holdStartTime = Time.time;

        OnButtonHold.Invoke(); // Trigger initial hold event
    }

    // Called when the button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        OnButtonRelease.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for continuous hold
        if (isHolding && Time.time - holdStartTime > holdThreshold)
        {
            OnButtonHold.Invoke();
            holdStartTime = Time.time; // Reset the hold start time
        }
    }
}
