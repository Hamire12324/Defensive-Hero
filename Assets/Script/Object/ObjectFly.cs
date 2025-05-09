using UnityEngine;

public class ObjectFly : MinhMonoBehaviour
{
    [Header("Object Fly")]
    [SerializeField] protected Vector3 direction = Vector3.left;
    [SerializeField] protected float speed;
    protected virtual void Update()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
    }
}
