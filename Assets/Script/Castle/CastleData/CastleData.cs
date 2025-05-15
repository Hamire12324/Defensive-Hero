using UnityEngine;
[CreateAssetMenu(menuName = "SO/Caslte Data")]

public class CastleData : ScriptableObject
{
    public int maxHP = 10;
    public int currentHP = 10;
    public void Reset()
    {
        currentHP = maxHP;
    }
}
