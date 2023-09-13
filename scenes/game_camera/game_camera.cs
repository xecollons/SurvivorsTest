using Godot;
using System;

public partial class game_camera : Camera2D
{
    Vector2 targetPosition = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MakeCurrent();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        acquireTarget();
        GlobalPosition = GlobalPosition.Lerp(targetPosition, 1 - MathF.Exp((float)-delta * 10));
    }

    void acquireTarget()
    {
        var playerNodes = GetTree().GetNodesInGroup("player");
        if (playerNodes.Count > 0)
        {
            var player = playerNodes[0] as Node2D;
            targetPosition = player.GlobalPosition;
        }
    }
}
