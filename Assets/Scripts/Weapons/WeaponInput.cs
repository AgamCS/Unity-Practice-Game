using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponInput : MonoBehaviour
{
    
    [SerializeField] Transform _aimTarget;
    [SerializeField] Transform _shootPoint;
    [SerializeField] WeaponScriptableObject _weaponInfo;
    Camera _camera;
    LineRenderer _aimPointer;
    Vector2 _screenBounds;

    int _bulletsLeft;
    bool _shootType;

    public WeaponScriptableObject WeaponInfo {get {return _weaponInfo;}}

    void Awake()
    {
        _bulletsLeft = _weaponInfo.MagazineSize;
        _aimPointer = GetComponent<LineRenderer>();
        _camera = Camera.main;
        _aimPointer.positionCount = 2;
        
    }

    void Update()
    {   
        // Determine if firing happens when the fire button is held or when its pressed
        
        if (_weaponInfo.FireType == FireType.AUTO) _shootType = Input.GetButton("Fire1");
        else _shootType = Input.GetButtonDown("Fire1");
        if (_shootType)
        {
            Shoot();
        }

        AimToTarget();
    }

    async void Shoot()
    {
        if (PlayerController.Instance.Shooting || _bulletsLeft <= 0 || PlayerController.Instance.Reloading)
        {
            return;
        }

        PlayerController.Instance.Shooting = true;
        RaycastHit rayHit;
        Vector3 direction = _shootPoint.position - _aimTarget.position;
        direction.z = 0;
        if (Physics.Raycast(_shootPoint.position, direction, out rayHit, Vector3.Distance(_shootPoint.position, _aimTarget.position)))
        {
            switch (rayHit.transform.gameObject.layer)
            {
                case 6:
                {
                    break;
                }
            }
        }
        await Task.Delay(_weaponInfo.RateOfFire);
        _bulletsLeft--;
        PlayerController.Instance.Shooting = false;
    }

    // Set the crosshair to the position of the mouse, and draw a line from the barrel of the gun to the crosshair
    void AimToTarget()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Vector3 targetPoint = _camera.ScreenToWorldPoint(mousePos);
        _aimTarget.position = targetPoint;
        _aimPointer.SetPosition(0, _shootPoint.position);
        _aimPointer.SetPosition(1, _aimTarget.position);
    }

    async void Reload()
    {
        PlayerController.Instance.Reloading = true;
        await Task.Delay(_weaponInfo.ReloadSpeed);
        PlayerController.Instance.Reloading = false;
        _weaponInfo.MaxAmmo -= (_weaponInfo.MagazineSize - _bulletsLeft);
    }

}
