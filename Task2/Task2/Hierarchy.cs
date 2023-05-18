using System;
using Task2;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Task2
{
	class GamePiece
	{
		public string name;
		public bool isOutofGame = false;
		public bool move1() {
			bool finished = false;
			/*
			 * 
			 * 
			 * 
			 * finised = true;
			 * */
			return finished;
		}
	}

	class Pawn:GamePiece
	{ 
		
	}
	class Bishop:GamePiece
	{ 
		
	}
	class Rook:GamePiece
	{ 
		
	}
	class Knight : GamePiece
	{

	}
	class Queen : GamePiece
	{

	}
	class King : GamePiece
	{
		
	}
}
