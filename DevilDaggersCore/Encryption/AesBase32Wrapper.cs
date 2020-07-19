using System;
using System.Security.Cryptography;
using System.Text;

namespace DevilDaggersCore.Encryption
{
	/// <summary>
	/// Taken from http://mjremijan.blogspot.com/2014/08/aes-encryption-between-java-and-c.html.
	/// </summary>
	public class AesBase32Wrapper
	{
		private readonly string initializationVector;
		private readonly string password;
		private readonly string salt;

		public AesBase32Wrapper(string initializationVector, string password, string salt)
		{
			this.initializationVector = initializationVector;
			this.password = password;
			this.salt = salt;
		}

		private enum TransformType
		{
			Encrypt,
			Decrypt,
		}

		public string EncryptAndEncode(string inputRaw)
		{
			// The raw input is in UTF-8 format.
			byte[] buffer = Encoding.UTF8.GetBytes(inputRaw);

			using AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
			ICryptoTransform encryptor = GetCryptoTransform(csp, TransformType.Encrypt);
			byte[] encrypted = encryptor.TransformFinalBlock(buffer, 0, buffer.Length);

			// The encrypted output is in Base32 format.
			return Base32Encoding.ToString(encrypted);
		}

		public string DecodeAndDecrypt(string inputEncrypted)
		{
			// The encrypted input is in Base32 format.
			byte[] buffer = Base32Encoding.ToBytes(inputEncrypted);

			using AesCryptoServiceProvider csp = new AesCryptoServiceProvider();
			ICryptoTransform decryptor = GetCryptoTransform(csp, TransformType.Decrypt);
			byte[] decrypted = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);

			// The decrypted output is in UTF-8 format.
			return Encoding.UTF8.GetString(decrypted);
		}

		private ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, TransformType transformType)
		{
			csp.Mode = CipherMode.CBC;
			csp.Padding = PaddingMode.PKCS7;
			csp.IV = Encoding.UTF8.GetBytes(initializationVector);

			using Rfc2898DeriveBytes spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), 65536);
			byte[] key = spec.GetBytes(16);
			csp.Key = key;

			return transformType switch
			{
				TransformType.Encrypt => csp.CreateEncryptor(),
				TransformType.Decrypt => csp.CreateDecryptor(),
				_ => throw new Exception($"Unknown {nameof(TransformType)} '{transformType}'."),
			};
		}
	}
}