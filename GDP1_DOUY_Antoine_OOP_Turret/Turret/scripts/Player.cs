using Godot;
using System;

// Author : 

namespace Com.IsartDigital.ProjectName {
	
	public partial class Player : Movable
	{
		[Export]
		public PackedScene bullet;

		Vector2 Direction;
		
		public Area2D lbullet;

		AnimatedSprite2D lAnimation;
		CollisionShape2D lHitbox;
        
		public Player() { }

        static public Player GetInstance()
		{
			if (instance == null) instance = new Player();
			return instance;

		}
		public override void _Ready()
		{
			if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(Player) + " Instance already exist, destroying the last added.");
				return;
			}
			instance = this;

            lAnimation = (AnimatedSprite2D)GetChild(0);
            base.PlayerSpawn();
            AreaEntered += EnemyColision;
			
			lHitbox = (CollisionShape2D)GetChild(1);
            shieldSize = ((CircleShape2D)lHitbox.Shape).Radius;



        }

        private void EnemyColision(Area2D area)
        {

			if(area is Enemy)
			{
				lAnimation.Play();
			}

        }

        public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;
			MovePlayer();
			InputClick();
        }

		protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}

		public virtual void MovePlayer()
		{
            cannon = GetChild<Sprite2D>(2);
            Vector2 lDirection = GetGlobalMousePosition() - Position;
			cannon.Rotation = Mathf.Atan2(lDirection.Y, lDirection.X);
		}
		
		public virtual void PositionBall()
		{
            lbullet = (Area2D)bullet.Instantiate();
            
			Marker2D lmarker = (Marker2D)cannon.GetChild(0);
            
			lbullet.Position = lmarker.GlobalPosition - Position;
        }
		
		
		public virtual void InputClick()
        {
            if (Input.IsActionJustPressed("shoot"))
            {
                PositionBall();
                AddChild(lbullet);
            }
        }
   
	
	
	
	
	
	
	
	}
}

