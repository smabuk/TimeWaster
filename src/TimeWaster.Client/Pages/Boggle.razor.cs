using Microsoft.AspNetCore.Components;
using Smab.DiceAndTiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWaster.Client.Pages
{
    public class BoggleBase : ComponentBase
    {
		[Parameter] public string BoggleType { get; set; }
		[Parameter] public int NoOfPlayers { get; set; }

		public BoggleDice BoggleSet { get; set; }
		public BoggleDice.BoggleType BoggleSetType
			=> BoggleType switch
			{
				"classic" => BoggleDice.BoggleType.Classic4x4,
				"deluxe" => BoggleDice.BoggleType.BigBoggleDeluxe,
				"superbig" => BoggleDice.BoggleType.SuperBigBoggle2012,
				_ => BoggleDice.BoggleType.Classic4x4
			};

		protected int BoardSize => BoggleSet.BoardSize;
		protected readonly double DieSize = 8;
		protected readonly double DieFontSize = 4.8;


		protected override void OnInitialized()
		{
			// Provide defaults for optional parameters
			NoOfPlayers = NoOfPlayers switch
			{
				0 => 1,
				{ } => NoOfPlayers
			};
			BoggleType = BoggleType ?? "classic";

			// Initialise the Boggle board
			BoggleSet = new BoggleDice(BoggleSetType);
			BoggleSet.ShakeAndFillBoard();

		}

		protected void Shake()
		{
			BoggleSet.ShakeAndFillBoard();
		}

	}
}
