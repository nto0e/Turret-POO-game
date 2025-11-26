using Godot;
using System;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

// Author : 

namespace Com.IsartDigital.ProjectName {
	
	public partial class Hud : Control
	{
		const string SCORE_PREFIXE = " SCORE : ";
		static int score = 0;
        const int newScore = 1000;

		[Export] 
		Label scoreText;
		
		static private Hud instance;

		private Hud() { }

		static public Hud GetInstance()
		{
			if (instance == null) instance = new Hud();
			return instance;
			
		}

		public override void _Ready()
		{
            
		}
        

        public override void _Process(double pDelta)
		{
            float lDelta = (float)pDelta;
            scoreText.Text = SCORE_PREFIXE + score;
		}

		protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}

		public virtual int ScoreUpdate()
		{
			score += newScore;
			
			return score;
        }


	}
}
