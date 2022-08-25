using UnityEngine;


public abstract class BindableObject<T> : MonoBehaviour, IStateConnectable<T>
where T : class, new()
{
    public Entity Entity { get => this.GetObject(); }

    [field: SerializeField]
    public Object Object { get; set; }

    public abstract T State { get; set; }

    protected virtual void Awake()
    {
        IStateConnectable<T> stateConnectable = this;
        StartCoroutine(stateConnectable.Join());
    }
}