using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirectShooter : BallShooter
{
    [SerializeField] private ShootAimer _aimer;
    [SerializeField] private GameObject _ball;
    [SerializeField] private ParticleSystem _ballParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void SetAimer(ShootAimer aimer)
    {
        _aimer = aimer;
    }
    public override void Shoot()
    {
        StartCoroutine(Shooting());
        _ballParticle = Instantiate(_ballParticle);
    }
    private IEnumerator Shooting()
    {
        var speed = 0.001f;
        var defaultDistance = _aimer.transform.position.z - _ball.transform.position.z;
        var defaultBallPos = _ball.transform.position;
        var slowPercent = 0.03f;

        while (true)
        {
            //замедление мяча первые пару метров
            var passedDistance = Math.Abs(_ball.transform.position.z - defaultBallPos.z);
            if(passedDistance < slowPercent * defaultDistance)
            {
                _ball.transform.position = Vector3.Lerp(_ball.transform.position, _aimer.transform.position, 0.05f * speed);
                speed += 0.0001f;
            }
            else
            {
                _ball.transform.position = Vector3.Lerp(_ball.transform.position, _aimer.transform.position, speed);
                speed += 0.001f;
            }
            _ball.transform.Rotate(-20,0,0);
            _ballParticle.transform.position = _ball.transform.position;
            yield return new WaitForFixedUpdate();
        }
       
    }
}
