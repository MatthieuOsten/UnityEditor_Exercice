using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("SYSTEM")]
    [SerializeField] private InputPlayer _inputs;

    [Header("MOVEMENT")]
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private InputPlayer Inputs { get { return _inputs; } }

    private void Start()
    {
        Inputs.Enable();
    }

    private void FixedUpdate()
    {
        Movement(GetInputMovement());
    }

    /// <summary>
    /// Get this frame player movement inputs.
    /// </summary>
    public Vector3 GetInputMovement()
    {
        float horizontal = Inputs.Player.MoveRight.ReadValue<float>();
        float forward = Inputs.Player.MoveForward.ReadValue<float>();

        return new Vector3(horizontal, 0f, forward) * _speed * Time.deltaTime;
    }

    private void Movement(Vector3 movement)
    {
        if (Inputs == null) { return; }

        _rigidbody.position += movement;
    }

}
