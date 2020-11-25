using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool isTouch = false;
    public float stickAngle = 0f;
    public Vector2 stickVec = Vector2.zero;

    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform stick;

    private float radius;
    private Vector2 value = Vector2.zero;
    private Canvas canvas;


    public void OnDrag(PointerEventData eventData)
    {
        StickMovement(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StickMovement(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        stick.localPosition = Vector3.zero;
        value = Vector2.zero;
    }

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        radius = background.rect.width * 0.5f;
    }

    public void StickMovement(PointerEventData eventData)
    {
        value = eventData.position - (Vector2)background.position;
        value = Vector2.ClampMagnitude(value, radius);

        stick.localPosition = value;

        isTouch = true;

        stickVec = value / radius;

        if (value.sqrMagnitude > radius * radius * 0.01f)
        {
            stickAngle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg - 90f;
        }
        else
        {
            isTouch = false;
            value = Vector2.zero;
            stickAngle = 0;
        }
    }
}
