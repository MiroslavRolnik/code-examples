using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD.PayAut.Business.WS.ENT
{
	public enum MaritalStatus
	{
		/// <summary>
		/// svobodný
		/// </summary>
		S,
		/// <summary>
		/// rozvedený
		/// </summary>
		R,
		/// <summary>
		/// ženatý
		/// </summary>
		M,
		/// <summary>
		/// vdovec
		/// </summary>
		B,
		/// <summary>
		/// partner
		/// </summary>
		P,
		/// <summary>
		/// zánik partnerství - rozluka
		/// </summary>
		Z,
		/// <summary>
		/// zánik partnerství - úmrtí
		/// </summary>
		U,
	}
}
