using System;
using System.Collections.Generic;
using UnityEngine;
using Collider = UnityEngine.Collider2D;
using Collision = UnityEngine.Collision2D;
using ContactPoint = UnityEngine.ContactPoint2D;

[Serializable]
public class Detector : IStateHandler<Collider>
{
    private Collider handle = null;
    private List<ContactPoint> contacts = new();
    public readonly Action<ContactPoint> onContactPoint;

    [field: SerializeField]
    public virtual List<LayerMask> DetectableLayerMasks { get; set; } = new();

    //OnCollision같은 곳에서 호출하면 좋음.
    public virtual Collider Handle
    {
        get
        {
            return handle;
        }
        set
        {
            handle = value;
            handle.GetContacts(contacts);
            ContactPoint contactLast = default;
            foreach (ContactPoint point in contacts)
            {
                if (point.Equals(contactLast))
                {
                    break;
                }
                contactLast = point;
                onContactPoint(point);
            }
        }
    }

    public virtual void MergeAllLayerMask()
    {
        for (int i = 1; i < DetectableLayerMasks.Count; i++)
        {
            DetectableLayerMasks[0] += DetectableLayerMasks[i];
            Debug.Log(DetectableLayerMasks[i].ToString());
        }
    }

    public Detector(Action<ContactPoint> onContact)
    {
        MergeAllLayerMask();
        onContactPoint = onContact;
    }
}

public static class DetectorExtender
{
    public static LayerMask GetLayerMask(this Collision collision)
    {
        return collision.gameObject.layer;
    }

    public static LayerMask GetLayerMask(this ContactPoint contactPoint2D)
    {
        return contactPoint2D.collider.GetLayerMask();
    }
}