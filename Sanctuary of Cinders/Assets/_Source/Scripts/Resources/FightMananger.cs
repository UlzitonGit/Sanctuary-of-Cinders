using UnityEngine;
using Zenject;
public class FightMananger : MonoBehaviour
{
    [SerializeField] private FightZoneSettings[] _fightZonesSettings;
    private SoundsPlayer _soundMananger;
    private ResourcesMananger _resources;
    private float _saveDuration = 10;
    [Inject]
    private void Construct(ResourcesMananger resources, SoundsPlayer soundMananger)
    {
        _resources = resources;
        _soundMananger = soundMananger;
    }

    public void FightForZone(int zoneIndex)
    {
        if (_fightZonesSettings[zoneIndex].GetSamuraiCount() <= _resources.Samurai)
        {
            _resources.AddSamurai(_fightZonesSettings[zoneIndex].GetSamuraiCount() * -1);
            _resources.AddCostMultiply(_fightZonesSettings[zoneIndex].GetMultiplyIndex());
            _soundMananger.PlayWin();
        }
        else
        {
            _soundMananger.PlayCant();
        }
    }
}
