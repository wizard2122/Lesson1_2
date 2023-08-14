using System.Collections.Generic;
using UnityEngine;

public class PointByPointMover: IMover
{
    private const float MinDistanceToTarget = 0.05f;

    private IMovable _movable;
    private Queue<Vector3> _targets;

    private Vector3 _currentTarget;

    private bool _isMoving;

    public PointByPointMover(IMovable movable, IEnumerable<Vector3> targets)
    {
        _targets = new Queue<Vector3>(targets);
        _movable = movable; 
        SwitchTarget();
    }

    private Transform Transform => _movable.Transform;
    private float Speed => _movable.Speed;

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update(float deltaTime)
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _currentTarget - Transform.position;
        Transform.Translate(direction.normalized * Speed * deltaTime);

        if(direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();
    }

    private void SwitchTarget()
    {
        if(_currentTarget != null)
            _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
    }
}
