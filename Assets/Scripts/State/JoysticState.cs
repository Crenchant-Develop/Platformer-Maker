using System;
using UnityEngine;


[Serializable]
public class JoysticState : IStateHandler<(RectTransform center, RectTransform selection, float maxDistance)>
{
    public (RectTransform center, RectTransform selection, float maxDistance) handle;
    public (RectTransform center, RectTransform selection, float maxDistance) Handle 
    {
        get
        {
            return handle;
        }
        set 
        {
            handle = value;
            Center = handle.center;
            Selection = handle.selection;
            MaxDistance = handle.maxDistance;
        }
    }

    [field: SerializeField]
    public RectTransform Center { get; set; }

    [field: SerializeField]
    public RectTransform Selection { get; set; }

    [field:SerializeField]
    public float MaxDistance { get; private set; }

    public Vector2 CenterPostision { get => Center.position; set => Center.position = value; }
    public Vector2 SelectionPostision { get => Selection.position; set => Selection.position = value; }
    public Vector2 SelectionLocalPostision { get => Selection.anchoredPosition; set => Selection.anchoredPosition = value; }
    
    public Vector2 InputValue { get => SelectionLocalPostision.normalized; }
}