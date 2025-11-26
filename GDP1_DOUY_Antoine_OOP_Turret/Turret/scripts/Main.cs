using Com.IsartDigital.ProjectName;
using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public partial class Main : Node2D
{
    [Export]
    Node2D gameContainer;

    [Export]
    public PackedScene packedEnemy;

    [Export]
    PackedScene packedPlayer;

    [Export]
    PackedScene packedHUD;

    [Export]
    public PackedScene packedShot;

    [Export]
    Control userInterface;

    [Export]
    PackedScene packedExplosion;

    static public  AnimatedSprite2D explosion;

    static public Area2D lEnemy;


    public override void _Ready()
    {
        AddChild(packedPlayer.Instantiate() as Player);

        for (int i = 0; i < 20; i++)
        {
          lEnemy = packedEnemy.Instantiate() as Enemy;
          AddChild(lEnemy);
        }

        AddChild(packedHUD.Instantiate() as Hud);
        
        explosion = packedExplosion.Instantiate() as AnimatedSprite2D;
        AddChild(explosion);
    }

}

