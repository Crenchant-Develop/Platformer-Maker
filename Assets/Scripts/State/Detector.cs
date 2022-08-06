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
    private Action<ContactPoint> handleInvoke = null;
    private List<ContactPoint> contacts = new();

    [field: SerializeField]
    public virtual List<LayerMask> DetectableLayerMasks { get; set; }
    public virtual Collider Handle
    {
        get
        {
            return handle;
        }
        set
        {
            //충돌시 정보가 여기에 들어오며,
            //handleInvoke 대리자를 사용하여 contacts의 정보를 확인할 수 있음
            handle = value;
            handle.GetContacts(contacts);

            if (handleInvoke is null)
            {
                return;
            }
            foreach (var contact in contacts)
            {
                LayerMask layerMask = contact.GetLayerMask();
                if (layerMask.Equals(DetectableLayerMasks[0]))
                {
                    handleInvoke(contact);
                }
            }
        }
    }

    public virtual Action<ContactPoint> OnHandleInvoke
    {
        get => handleInvoke;
        set => handleInvoke = value;
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