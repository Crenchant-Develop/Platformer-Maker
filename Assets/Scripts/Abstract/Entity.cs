using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.GameObject;

public class Entity
{
    public Object Self { get; }
    public LayerMask LayerMask { get; }

    public Transform Transform { get; }

    public T GetComponent<T>() where T : Component
    {
        return Self.GetComponent<T>();
    }

    public T[] GetComponents<T>() where T : Component
    {
        return Self.GetComponents<T>();
    }

    public static implicit operator Object(Entity entity)
    {
        return entity.Self;
    }
    public static implicit operator Entity(Object @object)
    {
        return new(@object);
    }

    public static implicit operator Entity(Component @object)
    {
        return new(@object);
    }

    public Entity(Object @object)
    {
        Self = @object;
        LayerMask = @object.layer;
        Transform = @object.transform;
    }

    public Entity(Component component) : this(component.GetObject())
    {
    }
}

public static class EntityExtender
{
    public static LayerMask GetLayerMask(this Component component)
    {
        return component.gameObject.layer;
    }

    public static Object GetObject(this Component component) 
    {
        return component.gameObject;
    }

    public static Object GetObject(this Entity entity)
    {
        return entity.Self;
    }
}