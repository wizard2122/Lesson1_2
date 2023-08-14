using UnityEngine;

public class MoveToTargetPattern : IMover
{
    private Transform _target;
    private IMovable _movable;

    private bool _isMoving;

    public MoveToTargetPattern(IMovable movable, Transform target)
    {
        _target = target;
        _movable = movable;
    }

    private Transform Transform => _movable.Transform;
    private float Speed => _movable.Speed;

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update(float deltaTime)
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _target.position - Transform.position;
        Transform.Translate(direction.normalized * Speed * deltaTime);
    }
}
