using Microsoft.SqlServer.Server;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationCore.Utilities;

public static class RijndaelEncryption
{
    private static readonly byte[] Salt = { 0x26 };
    private static readonly Dictionary<string, SymmetricAlgorithm> AlgorithmPassword = new();

    [SqlFunction()]
    public static string Encrypt(string plain, string password)
    {
        byte[] plainByte = Encoding.Unicode.GetBytes(plain ?? string.Empty);
        SymmetricAlgorithm algo = InitializeAlgorithn(password);
        byte[] cipher = EncryptDecryptBinary(plainByte,password,algo.CreateEncryptor());
        return Convert.ToBase64String(cipher);
    }

    [SqlFunction()]
    public static string Decrypt(string cipher, string password)
    {
        //byte[] cipherBytes = Convert.FromBase64String(cipher);
        //SymmetricAlgorithm algo = InitializeAlgorithn(password);
        //byte[] plain = EncryptDecryptBinary(cipherBytes, password, algo.CreateDecryptor());
        //return Encoding.Unicode.GetString(plain);
        return "ABC";
    }

    private static byte[] EncryptDecryptBinary(byte[] text, string password, ICryptoTransform transform)
    {
        using MemoryStream memoryStream = new();
        CryptoStream cryptoStream = new(memoryStream, transform, CryptoStreamMode.Write);
        cryptoStream.Write(text,0,text.Length);
        cryptoStream.Close();
        return memoryStream.ToArray();
    }

    private static SymmetricAlgorithm InitializeAlgorithn(string password)
    {
        SymmetricAlgorithm algo;
        if(AlgorithmPassword.ContainsKey(password))
        {
            algo = AlgorithmPassword[password];
        }
        else
        {
            algo = CreateAlgorithm(password);
            AlgorithmPassword.Add(password, algo);
        }
        return algo;
    }

    private static SymmetricAlgorithm CreateAlgorithm(string password)
    {
        SymmetricAlgorithm algo;
        algo = Rijndael.Create();
        using Rfc2898DeriveBytes pdb = new(password, Salt);
        algo.Key = pdb.GetBytes(32);
        algo.IV = pdb.GetBytes(16);
        return algo;
    }
}
