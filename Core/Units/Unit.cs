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

    private double lastAttackTime;
    private Unit? target;
    private NavigationAgent2D navigationAgent2D = new();

    public override void _Ready()
    {
        navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
        CurrentHp = MaxHp;
    }

    public override void _Process(double delta)
    {
        if (!navigationAgent2D.IsNavigationFinished())
        {
            Move(delta);
        }

        TargetCheck();
    }

    private void Move(double delta)
    {
        var nextPos = navigationAgent2D.GetNextPathPosition();
        var moveDir = GlobalPosition.DirectionTo(nextPos);
        var movement = moveDir * Speed * (float)delta;
        Translate(movement);
    }

    private void TargetCheck()
    {
        if (target is null || !IsInstanceValid(target))
        {
            return;
        }

        var dist = GlobalPosition.DistanceTo(target.Position);
        if (dist <= AttackRange)
        {
            navigationAgent2D?.TargetPosition = GlobalPosition;
            TryAttackTarget(target);
        }
        else
        {
            navigationAgent2D.TargetPosition = target.Position;
        }
    }

    private void TryAttackTarget(Unit u)
    {
        var time = Time.GetUnixTimeFromSystem();
        if (time - lastAttackTime < AttackRate)
        {
            return;
        }

        lastAttackTime = time;
        u.TakeDamage(AttackDamage);
    }

    private void TakeDamage(int ammount)
    {
        CurrentHp -= ammount;
        Damaged?.Invoke(CurrentHp);
        if (CurrentHp <= 0)
        {
            Die();
        }
        GD.Print($"[Unit] Damage dealed. CurrentHp={CurrentHp}");
    }

    private void Die()
    {
        Died?.Invoke(this);
        QueueFree();
    }

    public void SetMoveToTarget(Vector2 pos)
    {
        navigationAgent2D?.TargetPosition = pos;
        target = null;
    }

    public void SetAttackTarget(Unit u)
    {
        if (u.Team == Team)
        {
            return;
        }

        target = u;
    }
}
