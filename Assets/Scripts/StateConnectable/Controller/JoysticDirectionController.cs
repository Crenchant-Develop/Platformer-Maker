using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoysticDirectionController : DirectionController, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    JoysticState joysticState = new();
    [SerializeField]
    [Range(0f, 180f)]
    float topCastRange = 120f;

    public void OnPointerDown(PointerEventData eventData)
    {
        joysticState.Center.GetObject().SetActive(true);
        OnDragUpdate(eventData.position);
        joysticState.Center.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragUpdate(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joysticState.Center.GetObject().SetActive(false);
        OnDragUpdate(Vector2.zero);
    }

    void OnDragUpdate(Vector2 press)
    {
        if (press == Vector2.zero)
        {
            joysticState.SelectionLocalPostision = press;
            return;
        }
        joysticState.SelectionPostision = press;
        joysticState.SelectionLocalPostision = Vector2.ClampMagnitude(joysticState.SelectionLocalPostision, joysticState.MaxDistance);
    }

    bool IsTopCast
    {
        get => ClampAngle(joysticState.InputValue, 90f - topCastRange * 0.5f, 90f + topCastRange * 0.5f, out float angle) == angle;
    }

    void Update()
    {
        if (State is not null)
        {
            State.Vertical = IsTopCast ? joysticState.InputValue.y : 0f;
            State.Horizontal = joysticState.InputValue.x;
        }
    }
}