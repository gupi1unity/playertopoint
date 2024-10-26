using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer
{
    private Camera _camera;
    private LayerMask _groundLayer;
    private Vector3 _point;
    private GameObject _pointObject;

    public Pointer(Camera camera, LayerMask groundLayer, GameObject pointObject)
    {
        _camera = camera;
        _groundLayer = groundLayer;
        _pointObject = pointObject;

        _pointObject.SetActive(true);
    }

    public Vector3 GetPoint()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        _point = Vector3.zero;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, _groundLayer.value))
        {
            _point = hitInfo.point;
            MoveObjectToPoint();
        }

        return _point;
    }

    private void MoveObjectToPoint()
    {
        _pointObject.transform.position = _point;
    }
}
