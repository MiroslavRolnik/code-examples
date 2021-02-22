using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOrder
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Začátek:");
			try
			{
				for (int i = 0; i < 100; i++)
				{
					TestRun(10, 10000);
					Console.WriteLine($"Test #{i} OK");
				}

				Console.WriteLine("100% OK");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Nic: " + ex.Message);
			}
			Console.WriteLine("Konec");
			Console.ReadLine();
		}

		private static Random _Random = new Random();

		private static void TestRun(int bufferLength, int indexLength)
		{
			List<int> bufferArray = CreateBuffer(bufferLength);

			List<int> indexArray = new List<int>();
			int newIndex = bufferLength;
			for (int i = 0; i < indexLength; i++)
			{
				int index = GetValueFromBuffer(i, bufferLength, bufferArray, newIndex++, indexLength);

				if (index >= 0)
					indexArray.Add(index);
				else
					throw new Exception("Index not found!");
			}

			if (!CheckArray(indexArray, bufferLength))
				throw new Exception("Array check failed");
		}		

		private static List<int> CreateBuffer(int length)
		{
			List<int> bufferArray = new List<int>();

			for (int i = 0; i < length; i++)
				bufferArray.Add(i);

			for (int i = 0; i < length - 1; i++)
			{
				int index = _Random.Next(i, length);
				int temp = bufferArray[index];
				bufferArray[index] = bufferArray[i];
				bufferArray[i] = temp;
			}

			return bufferArray;
		}

		private static int GetValueFromBuffer(int i, int bufferLength, List<int> buffer, int newIndex, int indexLength)
		{
			int retval = -1;

			int[] indices = new int[buffer.Count];
			for (int j = 0; j < indices.Length; j++)
				indices[j] = j;

			int minIndex = buffer.Min();
			for (int j = 0; j < indices.Length; j++)
			{
				int indIndex = _Random.Next(j, indices.Length);
				int index = indices[indIndex];
				indices[indIndex] = indices[j];
				indices[j] = index;

				int indexToAdd = buffer[index];

				bool indexFound = (minIndex == i + 1 - bufferLength && indexToAdd == minIndex)
					|| (minIndex > i + 1 - bufferLength && i < indexToAdd + bufferLength && i > indexToAdd - bufferLength);
				if (indexFound)
				{
					if (newIndex < indexLength)
						buffer[index] = newIndex++;
					else
						buffer.RemoveAt(index);

					retval = indexToAdd;

					break;
				}
			}

			return retval;

		}

		private static bool CheckArray(List<int> array, int length)
		{
			bool isChecked = true;

			for (int i = 0; i < array.Count; i++)
			{
				int minIndex = Math.Max(i - length, 0);
				int maxIndex = Math.Min(i + length, array.Count);

				if (!array.Where((ind) => ind >= minIndex && ind < maxIndex).Contains(i))
				{
					isChecked = false;
					break;
				}
			}

			return isChecked;
		}

	}
}
