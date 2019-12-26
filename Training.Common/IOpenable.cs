using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Common
{
	public interface IOpenable
	{
		/// <summary>
		/// Checks if connection is open.
		/// </summary>
		bool IsOpen { get; }

		/// <summary>
		/// Opens this object.
		/// </summary>
		void Open();

		/// <summary>
		/// Closes this object.
		/// </summary>
		void Close();
	}
}
