using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{

	[Serializable]
	public class InvalidVoteException : Exception
	{
		public InvalidVoteException()
		{ }
		public InvalidVoteException(int vote) : base($"The value \"{vote}\" does not correspond with the real one")
		{ }
	}
}
  
