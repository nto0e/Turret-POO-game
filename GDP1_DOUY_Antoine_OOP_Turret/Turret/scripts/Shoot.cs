using Godot;
using System;

// Author : nto

namespace Com.IsartDigital.ProjectName
{

    public partial class Shoot : Player
    {
        float myFloat;
        public override void _Ready()
        {
            myFloat = Player.cannon.Rotation;
            lScreen = GetViewportRect();
            AreaEntered += EnemyColision;
        }

        private void EnemyColision(Area2D area)
        {
            if (area is Enemy)
            {
                QueueFree();
                area.QueueFree();
                Hud.GetInstance().ScoreUpdate();


                Main.explosion.Position = area.Position;
                Main.explosion.Play();
                if (Main.explosion == null)
                {
                    QueueFree();
                }


            }


        }

        public override void _Process(double pDelta)
        {
            float lDelta = (float)pDelta;
            InputClick();
            Position += new Vector2(Mathf.Cos(myFloat), Mathf.Sin(myFloat)) * BULLET_SPEED;

            if (GlobalPosition.X > lScreen.Size.X || GlobalPosition.X < 0 || GlobalPosition.Y > lScreen.Size.Y || GlobalPosition.Y < 0)
            {
                QueueFree();
            }
           
        }
    }
}