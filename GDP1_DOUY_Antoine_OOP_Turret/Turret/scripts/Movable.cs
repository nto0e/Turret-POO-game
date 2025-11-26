using Godot;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

// Author : nto

namespace Com.IsartDigital.ProjectName {
	
	public partial class Movable : Area2D
	{

		public const int ENEMY_SPEED = 30;
        public const int BULLET_SPEED = 5;

        public Rect2 lScreen;

        public Vector2 ballVelocity;
        public Vector2 lBulletPos;
        
        static public Player instance;
        static public Sprite2D cannon;

        public Vector2 Size;
        public Vector2 lPos;

        static public Vector2 PlayerGlobalPosition;
        
        public List<Color> colors = new List<Color> { new Color(1, 0, 0, 1), new Color(0, 1, 0, 1), new Color(0, 0, 1, 1) };
        public List<Vector2> positionList = new List<Vector2>();

        public int ENEMY_SPACE = 70;
        public int NOISE = 50;

        public  string PATH_COLOR_ENEMY = "color";

        static public float shieldSize;

        public override void _Ready()
		{
			PlayerSpawn(); 
			EnemySpawn();
        }

        

        public virtual void PlayerSpawn()
		{
            lScreen = GetViewportRect();
            Position = lScreen.Size / 2;
            PlayerGlobalPosition = GlobalPosition;
		}

		public virtual void EnemySpawn()
		{
			lScreen = GetViewportRect();
			Position = new Vector2(lScreen.Size.X / 2 * GD.Randf(), lScreen.Size.Y / 2 * GD.Randf());
		}

       

    }
}
