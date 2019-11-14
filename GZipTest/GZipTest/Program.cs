using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.IO.Compression;

namespace GZipTest
{
	public class Program
	{
		static int Main(string[] args)
		{
			int retval = 0;
			try
			{
				retval = TestMain(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
#if DEBUG
			Console.ReadLine();
#endif
			return retval;
		}

		public static int TestMain(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			int threadCount = Environment.ProcessorCount;
			int chunkLength;
			CompressionMode compressionMode;
			string inputFileName;
			string outputFileName;

			CheckAndAssignValuesFromInput(args, out inputFileName, out outputFileName, out compressionMode, out chunkLength, ref threadCount);

			Stream inputStream = GetInputStream(inputFileName);

			Stream outputStream = GetOutputStream(outputFileName);

			try
			{
				if (compressionMode == CompressionMode.Compress)
					GZipTest.Compress(inputStream, outputStream, chunkLength, threadCount);
				else if (compressionMode == CompressionMode.Decompress)
					GZipTest.Decompress(inputStream, outputStream, chunkLength, threadCount);
			}
			catch (InvalidDataException ex)
			{
				throw new Exception("Incorrect data format", ex);
			}
			catch (OutOfMemoryException ex)
			{
				throw new Exception("System does not have sufficient memmory. Try to set up with additional parameters [chunkLengt] and [threadCount].", ex);
			}
			finally
			{
				inputStream?.Dispose();
				outputStream?.Dispose();
			}

			return 1;
		}

		private static void CheckAndAssignValuesFromInput(string[] args, out string inputFileName, out string outputFileName, out CompressionMode compressionMode, out int chunkLength, ref int threadCount)
		{
			if (args == null)
				throw new ArgumentNullException("Method expects threse arguments: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");
			if (args.Length > 5)
				throw new ArgumentException("Too many arguments, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");

			if (args.Length > 4)
			{
				if (!int.TryParse(args[4], out threadCount))
					throw new FormatException($"Could not parse value {args[4]} of the argument [threadCount], possible values are positive integers.");
				if (threadCount <= 0)
					throw new ArgumentOutOfRangeException($"Value of parameter [threadCount] must be greater than 0, currently is {threadCount}.");
			}

			if (args.Length > 3)
			{
				if (!int.TryParse(args[3], out chunkLength))
					throw new FormatException($"Could not parse value {args[3]} of the argument [chunkLength], possible values are positive integers.");
				if (chunkLength <= 0)
					throw new ArgumentOutOfRangeException($"Value of parameter [chunkLength] must be greater than 0, currently is {chunkLength}.");
			}
			else
				chunkLength = Math.Min((1 << 30) / (2 * threadCount), 1 << 20);

			if (args.Length > 2)
			{
				if (!Enum.TryParse(args[0], true, out compressionMode))
					throw new ArgumentOutOfRangeException($"Unknown value '{args[0]}' of argument, expects [compress|decompress].");
				inputFileName = args[1];
				outputFileName = args[2];
			}
			else
				throw new ArgumentException("One or more arguments are missing, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");
		}

		private static Stream GetInputStream(string inputFileName)
		{
			FileInfo fi = new FileInfo(inputFileName);

			if (!fi.Exists)
				throw new FileNotFoundException($"Input file {inputFileName} does not exist. Check if the name is correct.");

			Stream inputStream = null;
			try
			{
				inputStream = File.OpenRead(inputFileName);
			}
			catch (Exception ex)
			{
				throw new Exception($"Could not open input file {inputFileName} for reading.", ex);
			}

			return inputStream;

		}

		private static Stream GetOutputStream(string outputFileName)
		{
			Stream outputStream = null;
			try
			{
				outputStream = File.Create(outputFileName);
			}
			catch (Exception ex)
			{
				throw new Exception($"Could not open output file {outputFileName} for writting.", ex);
			}

			return outputStream;
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine($"Unexpected error occured. " + e.ExceptionObject);
		}
	}
}
