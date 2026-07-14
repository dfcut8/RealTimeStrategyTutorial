using System;
using Godot;

namespace RealTimeStrategy.Core.Units;

public partial class Unit : Area2D
{
    public Action<int>? Damaged;
    public Action<Unit>? Died;

    public enum TeamEnum
    {
        Player,
        Ai,
    }

    [Export]
    public float Speed { get; set; } = 30.0f;

    [Export]
    public int MaxHp { get; set; } = 100;

    [Export]
    public float AttackRange { get; set; } = 20.0f;

    [Export]
    public float AttackRate { get; set; } = 0.5f;

    [Export]
    public int AttackDamage { get; set; } = 5;

    [Export]
    public TeamEnum Team { get; set; }

    public int CurrentHp { get; set; }

    private float lastAttackTime;
    private Unit? target;
    private NavigationAgent2D navigationAgent2D = new();

    public override void _Ready()
    {
        navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
        SetMoveToTarget(Vector2.Zero);
    }

    public override void _Process(double delta)
    {
        if (!navigationAgent2D.IsTargetReached())
        {
            Move(delta);
        }
    }

    private void Move(double delta)
    {
        var nextPos = navigationAgent2D.GetNextPathPosition();
        var moveDir = GlobalPosition.DirectionTo(nextPos);
        var movement = moveDir * Speed * (float)delta;
        Translate(movement);
    }

    private void TargetCheck() { }

    private void TryAttackTarget() { }

    private void Die() { }

    public void SetMoveToTarget(Vector2 pos)
    {
        navigationAgent2D?.TargetPosition = pos;
        target = null;
    }

    public void SetAttackTarget(Unit target) { }

    public void TakeDamage(int ammount) { }
}
