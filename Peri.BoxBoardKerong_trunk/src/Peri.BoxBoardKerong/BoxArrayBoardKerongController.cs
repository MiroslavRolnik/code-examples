using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P4U.Peri.BoxBoardKerong.BoxArrayImplementation;
using P4U.Peri.BoxBoardKerong.Logger;

namespace P4U.Peri.BoxBoardKerong
{
    public class BoxArrayBoardKerongController
	{
		#region Properties

		public DriverCollection Drivers { get; private set; }

		public BoxHwCollection Boxes { get; private set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Provede init
		/// </summary>
		public void Init(ImplementationType type, InitDataSet ds)
		{
			if (type == ImplementationType.UNKNOWN)
			{
				throw new Exception($"Unknown BoxArrayBoardKerongController Type=[{type}]");
			}

			Drivers = new DriverCollection();
			Boxes = new BoxHwCollection();

			Driver driver = null;
			Module module = null;

			IEnumerable<InitDataSet.BoxRow> query =
				from box in ds.Box
				orderby box.DriverIpAddress, box.DriverPort, box.ModuleAddress, box.LogicalNumber
				select box;

			foreach (InitDataSet.BoxRow row in query)
			{
				Socket socket = new Socket(row.DriverIpAddress, row.DriverPort);

				driver = Drivers.GetDriverForSocket(socket);
				if (driver == null)
				{
					driver = new Driver(type, socket);
					Drivers.Add(socket, driver);
				}

				module = driver.Modules.GetModuleForAddress(row.ModuleAddress);
				if (module == null)
				{
					module = new Module(driver, row.ModuleAddress);
				}

				BoxHw box = new BoxHw(row.ID, module, row.LogicalNumber, row.ModulePortNumber);
				Boxes.Add(row.LogicalNumber, box);
			}

			foreach (Driver i in Drivers.Values)
			{
				i.Init();
			}
		}

		public void Init(ImplementationType type, DataTable table)
		{
			InitDataSet ds = new InitDataSet();

			foreach (DataRow row in table.Rows)
			{
				int id = (int)(row["ID"]);
				int boxLogicalNumber = (int)(row["LogicalNumber"]);
				byte modulePortNumber = (byte)(row["ModulePortNumber"]);
				byte moduleAddress = (byte)(row["ModuleAddress"]);
				string driverIpAddress = (string)(row["DriverIpAddress"]);
				int driverPort = (int)(row["DriverPort"]);

				ds.Box.AddBoxRow(id, boxLogicalNumber, modulePortNumber, moduleAddress, driverIpAddress, driverPort);
			}

			Init(type, ds);
		}

		public void Init(string typeString, DataTable boxDataTable)
		{
			Init(GetImplementationType(typeString), boxDataTable);
		}

		public void Init(string typeString, InitDataSet ds)
		{
			Init(GetImplementationType(typeString), ds);
		}

		public void Deinit()
		{
			foreach (Driver i in Drivers.Values)
			{
				i.Deinit();
			}

			Drivers = null;
			Boxes = null;
		}

		public void SetCommLogger(CommunicationLoggerType type, Dictionary<string, object> pars)
		{
			Global.SetCommLogger(type, pars);
		}

		#endregion

		#region Private Methods

		public ImplementationType GetImplementationType(string type)
		{
			switch (type.ToLower())
			{
				case "none": return ImplementationType.None;
				case "emulator": return ImplementationType.Emulator;
				case "kerong": return ImplementationType.Kerong;
				default: return ImplementationType.UNKNOWN;
			}
		}

		#endregion
	}
}
