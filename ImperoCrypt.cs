using System;
using System.Security.Cryptography;

namespace ImperoKeygen
{
	public class ImperoCrypt
	{
		public static string EncryptRijndael (string pStrData, string pPassword = "Imp3ro", bool pUsePadding = true)
		{
			RijndaelManaged rijndaelManaged = null;
			rijndaelManaged = new RijndaelManaged ();
			byte[] rgbKey = ImperoCrypt.CreateKey (pPassword);
			byte[] rgbIV = ImperoCrypt.CreateIV (pPassword);
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes (pStrData);

			rijndaelManaged.Padding = pUsePadding ? PaddingMode.ISO10126 : PaddingMode.PKCS7;

			return Convert.ToBase64String (rijndaelManaged.CreateEncryptor (rgbKey, rgbIV).TransformFinalBlock (bytes, 0, bytes.Length));
		}

		private static byte[] CreateKey (string strPassword)
		{
			char[] array = strPassword.ToCharArray ();
			int upperBound = array.GetUpperBound (0);
			byte[] array2 = new byte[upperBound + 1];
			int upperBound2 = array.GetUpperBound (0);

			for (int i = 0; i <= upperBound2; i++)
			{
				array2 [i] = (byte)array [i];
			}

			SHA512Managed sHA512Managed = new SHA512Managed ();
			byte[] array3 = sHA512Managed.ComputeHash (array2);
			byte[] array4 = new byte[32];
			int num = 0;
			do
			{
				array4 [num] = array3 [num];
				num++;
			}
			while (num <= 31);

			return array4;
		}

		private static byte[] CreateIV (string strPassword)
		{
			char[] array = strPassword.ToCharArray ();
			int upperBound = array.GetUpperBound (0);
			byte[] array2 = new byte[upperBound + 1];
			int upperBound2 = array.GetUpperBound (0);

			for (int i = 0; i <= upperBound2; i++)
			{
				array2 [i] = (byte) array [i];
			}

			SHA512Managed sHA512Managed = new SHA512Managed ();
			byte[] array3 = sHA512Managed.ComputeHash (array2);
			byte[] array4 = new byte[16];
			int num = 32;

			do
			{
				array4 [num - 32] = array3 [num];
				num++;
			}
			while (num <= 47);

			return array4;
		}
	}
}

