using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteAlways]
public class Player : MonoBehaviour
{
    [Header("SYSTEM")]
    [SerializeField] private InputPlayer _inputs;

    [Header("MOVEMENT")]
    [SerializeField] private float _speed;
    [SerializeField] private float _moveYMin,_moveYMax;
    [SerializeField] private float _moveXMin,_moveXMax;

    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _position;

    [SerializeField] private InputPlayer Inputs { get { return _inputs; } }

    private void Start()
    {
         if (_moveYMin == 0 && _moveYMax == 0)
        {
            _moveXMax = Camera.main.WorldToViewportPoint(transform.position).x;
            _moveXMax = transform.position.x - Camera.main.rect.xMax;
            _moveXMax = Camera.main.ScreenToWorldPoint(transform.position).y;
            _moveXMax = transform.position.y - Camera.main.rect.yMax;
        }
    }

    private void Update()
    {
        Camera camera = Camera.main;
        Vector3 p = new Vector3(camera.rect.xMax, camera.rect.yMax, transform.position.z);
        _position = camera.ScreenToWorldPoint(p);
        _position = camera.ViewportToWorldPoint(p);
        _position = camera.WorldToScreenPoint(p);
        _position = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, camera.nearClipPlane)); //- camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        _transform.position = _position;
        UpdateLimitScreen();
    }

    void OnDrawGizmos()
    {
        Camera camera = Camera.main;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_position, 0.1F);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camera.ScreenToWorldPoint(transform.position), camera.ScreenToWorldPoint(new Vector3(0, Screen.height, transform.position.z)));
    }

    private void UpdateLimitScreen()
    {
        _moveXMax = Camera.main.WorldToViewportPoint(transform.position).x;
        _moveXMax = transform.position.x - Camera.main.rect.xMax;
        _moveXMax = Camera.main.ScreenToWorldPoint(transform.position).y;
        _moveXMax = transform.position.y - Camera.main.rect.yMax;
    }

    private void Movement()
    {
        if (Inputs == null) { return; }

    }
}
