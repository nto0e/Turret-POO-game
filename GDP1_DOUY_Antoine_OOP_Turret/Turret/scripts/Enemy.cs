using Godot;

// Author : nto

namespace Com.IsartDigital.ProjectName
{
    public partial class Enemy : Movable
    {


        public override void _Ready()
        {
            base.EnemySpawn();

            RandomNumberGenerator lRand = new RandomNumberGenerator();

            Scale = new Vector2(lRand.Randf() < 0.5f ? -1 : 1, lRand.Randf() < 0.5f ? -1 : 1);

            GetNode<Sprite2D>(PATH_COLOR_ENEMY).SelfModulate = colors[lRand.RandiRange(0, colors.Count - 1)];

            int lCol = (int)(lScreen.Size.X / (ENEMY_SPACE + Size.X));
            int lRow = (int)(lScreen.Size.Y / (ENEMY_SPACE + Size.Y));


            int i, j;

            for (i = 0; i < lCol; i++)
            {
                for (j = 0; j < lRow; j++)
                {
                    lPos = new Vector2((ENEMY_SPACE + Size.X) / 2 + i * (ENEMY_SPACE + Size.X) + lRand.RandiRange(-NOISE, NOISE),
                                       (ENEMY_SPACE + Size.Y) / 2 + j * (ENEMY_SPACE + Size.Y) + lRand.RandiRange(-NOISE, NOISE));
                    if (lPos.DistanceTo(Player.GetInstance().GlobalPosition) > shieldSize + Size.Length() / 2) positionList.Add(lPos);

                }
            }

            i = positionList.Count;
            while (i > 1)
            {
                i--;
                j = lRand.RandiRange(0, i);
                lPos = positionList[j];
                positionList[j] = positionList[i];
                positionList[i] = lPos;
            }
            Position = lPos;
            AreaEntered += PlayerColision;

        }


        private void PlayerColision(Area2D area)
        {

            if (area is Player)
            {
                Scale *= -1;
            }

        }

        public override void _Process(double pDelta)
        {
            float lDelta = (float)pDelta;

            Size = new Vector2(GetChild<Sprite2D>(0).Texture.GetWidth(), GetChild<Sprite2D>(0).Texture.GetHeight());
            
            if ((GlobalPosition.X < Size.X / 2 && Scale.X < 0)
                || (GlobalPosition.X > lScreen.Size.X - Size.X / 2 && Scale.X > 0))
            {
                Scale *= new Vector2(-1f, 1f);
            }

            if ((GlobalPosition.Y < Size.Y / 2 && Scale.Y < 0)
                || (GlobalPosition.Y > lScreen.Size.Y - Size.Y / 2 && Scale.Y > 0))
            {
                Scale *= new Vector2(1f, -1f);
            }

            Position += Scale * ENEMY_SPEED * lDelta;

        }

    }
}
