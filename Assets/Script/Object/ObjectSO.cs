using UnityEngine;
[CreateAssetMenu(fileName = "Object", menuName = "SO/Object")]
public class ObjectSO : ScriptableObject
{
    public string objName = "Object";
    public ObjectType objectType;
    public double hpMax = 2;
}
