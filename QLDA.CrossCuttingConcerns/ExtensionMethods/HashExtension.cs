using System.Security.Cryptography;
using System.Text;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods;
public static class HashExtention
{
    [Obsolete("Obsolete")]
    public static string EncryptText(this string input, string password)
    {
        byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

        byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
        string result = Convert.ToBase64String(bytesEncrypted);
        return result;
    }
    public static bool IsHash(this string input)
    {
        // Kiểm tra xem chuỗi có phải là đoạn mã của MD5 không
        if (input.IsHashOfType(MD5.Create()))
            return true;

        // Kiểm tra xem chuỗi có phải là đoạn mã của SHA1 không
        if (input.IsHashOfType(SHA1.Create()))
            return true;

        // Kiểm tra xem chuỗi có phải là đoạn mã của SHA256 không
        if (input.IsHashOfType(SHA256.Create()))
            return true;

        // Các thuật toán hashing khác có thể được thêm vào ở đây nếu cần

        return false;
    }
    private static bool IsHashOfType(this string input, HashAlgorithm algorithm)
    {
        // Kiểm tra xem đầu vào có thể được giải mã từ Base64 không
        try
        {
            byte[] bytesToBeDecoded = Convert.FromBase64String(input);
            string decodedText = Encoding.UTF8.GetString(bytesToBeDecoded);

            // Tính toán hash của đầu vào
            byte[] hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(decodedText));

            // So sánh chuỗi đã giải mã với chuỗi hash
            string computedHash = Convert.ToBase64String(hashBytes);
            return input.Equals(computedHash);
        }
        catch (FormatException)
        {
            // Trong trường hợp không thể giải mã từ Base64, chuỗi không phải là đoạn mã hashing
            return false;
        }
    }
    [Obsolete("Obsolete")]
    public static string DecryptText(this string input, string password)
    {
        byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
        string result = Encoding.UTF8.GetString(bytesDecrypted);

        return result;
    }

    [Obsolete("Obsolete")]
    private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] saltBytes = [1, 2, 3, 4, 5, 6, 7, 8];

        using MemoryStream ms = new MemoryStream();
        using RijndaelManaged aes = new();
        aes.KeySize = 256;
        aes.BlockSize = 128;

        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);

        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            cs.Close();
        }
        var encryptedBytes = ms.ToArray();

        return encryptedBytes;
    }

    [Obsolete("Obsolete")]
    private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] saltBytes = [1, 2, 3, 4, 5, 6, 7, 8];

        using MemoryStream ms = new MemoryStream();
        using RijndaelManaged aes = new();
        aes.KeySize = 256;
        aes.BlockSize = 128;

        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);

        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
            cs.Close();
        }
        var decryptedBytes = ms.ToArray();

        return decryptedBytes;
    }
}
