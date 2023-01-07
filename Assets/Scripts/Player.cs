using Assets.Scripts;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShootAimer _aimerPrefab;
    [SerializeField] BallShooter _ballShooter;
    private bool _isAiming = false;

    private Gates _gates;
    private Team _team;
    void Start()
    {
        _team = Team.White;
        _gates = FindObjectsOfType<Gates>().FirstOrDefault(x=>x.Team != _team);
    }

    void Update()
    {
        if (!_isAiming && Input.GetMouseButton(0))
        {
            StartAiming();
            _isAiming = true;
        }
    }
    void StartAiming()
    {
        var aimer = Instantiate(_aimerPrefab, _gates.transform);
        aimer.SetShooter(_ballShooter);
        _ballShooter.SetAimer(aimer);
        //aimer.Shoot();
    }
}
