using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

class Test : MonoBehaviour
{
    [SerializeField]
    List<LayerMask> layerMaskList = new();
    List<ContactPoint2D> contacts = new();

    private void Awake()
    {
        foreach (var layerMask in layerMaskList)
        {
            layerMaskList[0] += layerMask;
            layerMaskList.Remove(layerMask);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerMaskList[0])
        {
            GetContacts(collision.collider);
        }
    }

    public void GetContacts(Collider2D collider2D)
    {
        collider2D.GetContacts(contacts);
        foreach (var contact in contacts)
        {
            print(contact.normal);
        }
    }
}


