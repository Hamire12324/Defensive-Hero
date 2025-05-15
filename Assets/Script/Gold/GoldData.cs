using UnityEngine;

[CreateAssetMenu(fileName = "GoldData", menuName = "Game/Gold")]
public class GoldData : ScriptableObject
{
    public int goldBase;
    public int goldCurrent;
    public void Reset()
    {
        goldCurrent = goldBase;
    }
}
