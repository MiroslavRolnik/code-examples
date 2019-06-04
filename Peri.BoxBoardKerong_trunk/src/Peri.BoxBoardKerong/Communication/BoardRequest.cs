using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	class BoardRequest
	{
		/// <summary>
		/// vrací pole ve formě:
		/// STX        ADDR       CMD        ETX        SUM
		/// (1 byte)   (1 byte)   (1 byte)   (1 byte)   (1 byte) 
		/// </summary>
		/// <param name="addr"></param>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public static byte[] Create(ADDR addr, CMD cmd)
		{
			List<byte> data = new List<byte>();

			foreach (var item in addr.GetMsg())
			{
				data.Add(item);
			}

			foreach (var item in cmd.GetMsg())
			{
				data.Add(item);
			}

			return Create(data.ToArray());
		}

		/// <summary>
		/// vrací pole ve formě:
		/// STX        DATA  ETX        SUM
		/// (1 byte)   ...   (1 byte)   (1 byte)  
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static byte[] Create(byte[] data)
		{
			byte[] req = new byte[data.Length + 3];

			req[0] = BoardCommon.STX;
			
			Array.Copy(data, 0, req, 1, data.Length);

			req[req.Length - 2] = BoardCommon.ETX;
			req[req.Length - 1] = BoardCommon.ComputeSum(req);

			return req;
		}
	}
}
