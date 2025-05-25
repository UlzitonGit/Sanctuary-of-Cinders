using UnityEngine;

public class FightZoneSettings : MonoBehaviour
{
     [SerializeField] private int _samuraiCount;
     [SerializeField] private int _multiplyIndex;
     public int GetSamuraiCount() { return _samuraiCount; }
     public int GetMultiplyIndex() { return _multiplyIndex; }
}
