using System;
using System.Collections.Generic;
using UnityEngine;
using Collider = UnityEngine.Collider2D;
using Collision = UnityEngine.Collision2D;
using ContactPoint = UnityEngine.ContactPoint2D;


[Serializable]
public class Detector : IStateHandler<Collision>
{
    private Collision handle;
    private List<ContactPoint> contacts = new();

    [field: SerializeField]
    public virtual List<LayerMask> DetectableLayerMasks { get; set; }
    public virtual Collision Handle
    {
        get
        {
            return handle;
        }
        set
        {
            handle = value;
            Collider collider = value.collider;

            collider.GetContacts(contacts);
        }
    }
    public virtual Action<ContactPoint> OnHandleInvoke
    {
        set
        {
            foreach (var contact in contacts)
            {
                LayerMask layerMask = contact.GetLayerMask();
                if (layerMask.Equals(DetectableLayerMasks[0]))
                {
                    value(contact);
                }
            }
        }
    }

    public virtual void MergeAllLayerMask()
    {
        for (int i = 1; i < DetectableLayerMasks.Count; i++)
        {
            DetectableLayerMasks[0] += DetectableLayerMasks[i];
        }
    }
}

public static class DetectorExtender
{
    public static LayerMask GetLayerMask(this Component component)
    {
        return component.gameObject.layer;
    }

    public static LayerMask GetLayerMask(this Collision collision)
    {
        return collision.gameObject.layer;
    }

    public static LayerMask GetLayerMask(this ContactPoint contactPoint2D)
    {
        return contactPoint2D.collider.GetLayerMask();
    }
}