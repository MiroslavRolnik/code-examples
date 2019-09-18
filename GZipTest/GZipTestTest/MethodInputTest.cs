using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace GZipTestTest
{
	[TestClass]
	public class MethodInputTest
	{
		[TestMethod]
		public void TestArguments()
		{
			Assert.ThrowsException<ArgumentNullException>(() => GZipTest.Program.TestMain(null),
				"Method expects threse arguments: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");

			Assert.ThrowsException<ArgumentException>(() => GZipTest.Program.TestMain(new string[] { }),
				"One or more arguments are missing, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");

			Assert.ThrowsException<ArgumentException>(() => GZipTest.Program.TestMain(new string[] { "compress" }),
				"One or more arguments are missing, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");

			Assert.ThrowsException<ArgumentException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig" }),
				"One or more arguments are missing, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");

			string value = "commpress";
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => GZipTest.Program.TestMain(new string[] { value, "test.orig", "test.arch" }),
				$"Unknown value '{value}' of argument, expects [compress|decompress].");

			value = "_1";
			Assert.ThrowsException<FormatException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig", "test.arch", value }),
				$"Could not parse value {value} of the argument [chunkLength], possible values are positive integers.");

			int i = 0;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig", "test.arch", i.ToString() }),
				$"Value of parameter [chunkLength] must be greater than 0, currently is {i}.");

			value = "_1";
			Assert.ThrowsException<FormatException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig", "test.arch", value }),
				$"Could not parse value {value} of the argument [threadCount], possible values are positive integers.");

			i = 0;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig", "test.arch", "1024", i.ToString() }),
				$"Value of parameter [threadCount] must be greater than 0, currently is {i}.");

			Assert.ThrowsException<ArgumentException>(() => GZipTest.Program.TestMain(new string[] { "compress", "test.orig", "test.arch", "1024", "5", "oneMore" }),
				"Too many arguments, method expects: [compress|decompress] [input file name] [output file name] ([chunkLengt]) ([threadCount]).");
		}

		[TestMethod]
		public void TestInputNotFound()
		{
			string fileName = nameof(TestInputNotFound) + ".orig";

			Assert.ThrowsException<FileNotFoundException>(() => GZipTest.Program.TestMain(new string[] { "compress", fileName, "test.arch" }),
				$"Input file {fileName} does not exist. Check if the name is correct.");
		}

		[TestMethod]
		public void TestCompress()
		{
			string origFile = nameof(TestCompress) + ".orig";
			string archFile = nameof(TestCompress) + ".arch";

			if (!FileExists(origFile))
				CreateTestFile(origFile);

			Assert.AreEqual(1, GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }));
		}


		[TestMethod]
		public void TestDecompress()
		{
			string origFile = nameof(TestCompress) + ".orig";
			string archFile = nameof(TestCompress) + ".arch";
			string decomFile = "_" + origFile;

			if (!FileExists(origFile))
				CreateTestFile(origFile);

			Assert.AreEqual(1, GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }));

			Assert.AreEqual(1, GZipTest.Program.TestMain(new string[] { "decompress", archFile, decomFile }));

			Assert.IsTrue(AreEqual(File.ReadAllBytes(origFile), File.ReadAllBytes(decomFile)));
		}

		[TestMethod]
		public void TestInputFileAlreadyOpen()
		{
			string origFile = nameof(TestCompress) + ".orig";
			string archFile = nameof(TestCompress) + ".arch";
			string decomFile = "_" + origFile;

			if (!FileExists(origFile))
				CreateTestFile(origFile);

			Stream file = new FileStream(origFile, FileMode.Open, FileAccess.Read, FileShare.None, 1024, false);

			Assert.ThrowsException<Exception>(() => GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }),
			$"Could not open input file {origFile} for reading.");
		}

		[TestMethod]
		public void TestOutputFileAlreadyOpen()
		{
			string origFile = nameof(TestCompress) + ".orig";
			string archFile = nameof(TestCompress) + ".arch";
			string decomFile = "_" + origFile;

			if (!FileExists(origFile))
				CreateTestFile(origFile);

			Assert.AreEqual(1, GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }));

			Stream file = new FileStream(archFile, FileMode.Open, FileAccess.Read, FileShare.None, 1024, false);

			Assert.ThrowsException<Exception>(() => GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }),
			$"Could not open output file {archFile} for writting.");
		}

		[TestMethod]
		public void TestDataError()
		{
			string origFile = nameof(TestDataError) + ".orig";
			string archFile = nameof(TestDataError) + ".arch";
			string decomFile = "_" + origFile;

			if (!FileExists(origFile))
				CreateTestFile(origFile);

			Assert.AreEqual(1, GZipTest.Program.TestMain(new string[] { "compress", origFile, archFile }));

			byte[] file = File.ReadAllBytes(archFile);

			file[0] = 0;

			File.WriteAllBytes(archFile, file);

			Assert.ThrowsException<Exception>(() => GZipTest.Program.TestMain(new string[] { "decompress", archFile, decomFile }));
		}

		bool AreEqual(byte[] first, byte[] second)
		{
			if (first?.Length != second?.Length)
				return false;

			int index = first.Length - 1;
			while (index >= 0 && first[index] == second[index--]) ;

			return index < 0;
		}

		bool FileExists(string fileName)
		{
			FileInfo fi = new FileInfo(fileName);

			return fi.Exists;
		}

		void CreateTestFile(string fileName)
		{
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			using (StreamWriter writer = new StreamWriter(stream))
			{
				for (int i = 0; i < 1_000_000; i++)
					writer.WriteLine(string.Format("{0:D6}{1}", i, new string('A', 20)));
			}
		}

	}
}
