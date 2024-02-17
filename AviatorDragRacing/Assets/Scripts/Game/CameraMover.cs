using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private void Update()
    {
        _camera.position = new Vector3(transform.position.x, _camera.position.y, _camera.position.z);
    }
}
