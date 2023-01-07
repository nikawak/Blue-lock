using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAimer : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    private BallShooter _shooter;

    private Transform transform;
    void Start()
    {
        transform = base.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Mouse X") * _sensivity;
        var y = Input.GetAxis("Mouse Y") * _sensivity;

        transform.Translate(x, y, 0);
        Shoot();
    }
    public void SetShooter(BallShooter shooter)
    {
        _shooter = shooter;
    }
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shooter.Shoot();
            transform.gameObject.SetActive(false);
        }
    }
}
