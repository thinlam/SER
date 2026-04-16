using System.Security.Cryptography;
using System.Text;

namespace BuildingBlocks.Application.Common;

/// <summary>
/// Helper class cho các chức năng mã hóa và giải mã
/// Cryptography helper class for encryption and decryption functions
/// </summary>
public static class CryptographyHelper
{
    /// <summary>
    /// Key mặc định sử dụng cho mã hóa Triple DES
    /// Default key used for Triple DES encryption
    /// </summary>
    private const string DefaultKey = "Vietinfo@#@!123";

    /// <summary>
    /// Mã hóa mật khẩu sử dụng Triple DES với key mặc định
    /// Encrypt password using Triple DES with default key
    /// </summary>
    /// <param name="password">Mật khẩu cần mã hóa</param>
    /// <returns>Chuỗi đã mã hóa dạng Base64</returns>
    public static string EncryptPassword(string password)
    {
        return EncryptPassword(password, DefaultKey);
    }

    /// <summary>
    /// Mã hóa mật khẩu sử dụng Triple DES với key tùy chỉnh
    /// Encrypt password using Triple DES with custom key
    /// </summary>
    /// <param name="password">Mật khẩu cần mã hóa</param>
    /// <param name="key">Key sử dụng cho mã hóa</param>
    /// <returns>Chuỗi đã mã hóa dạng Base64</returns>
    public static string EncryptPassword(string password, string key)
    {
        using var md5 = MD5.Create();
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var derivedKey = md5.ComputeHash(keyBytes);
        using var des3 = TripleDES.Create();
        des3.Key = derivedKey;
        des3.Mode = CipherMode.ECB;
        des3.Padding = PaddingMode.PKCS7;
        var textBytes = Encoding.UTF8.GetBytes(password);
        using var encryptor = des3.CreateEncryptor();
        var encrypted = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
        return Convert.ToBase64String(encrypted);
    }

    /// <summary>
    /// Giải mã mật khẩu sử dụng Triple DES với key mặc định
    /// Decrypt password using Triple DES with default key
    /// </summary>
    /// <param name="encryptedPassword">Mật khẩu đã mã hóa dạng Base64</param>
    /// <returns>Chuỗi đã giải mã</returns>
    public static string DecryptPassword(string encryptedPassword)
    {
        return DecryptPassword(encryptedPassword, DefaultKey);
    }

    /// <summary>
    /// Giải mã mật khẩu sử dụng Triple DES với key tùy chỉnh
    /// Decrypt password using Triple DES with custom key
    /// </summary>
    /// <param name="encryptedPassword">Mật khẩu đã mã hóa dạng Base64</param>
    /// <param name="key">Key sử dụng cho giải mã</param>
    /// <returns>Chuỗi đã giải mã</returns>
    public static string DecryptPassword(string encryptedPassword, string key)
    {
        using var md5 = MD5.Create();
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var derivedKey = md5.ComputeHash(keyBytes);
        using var des3 = TripleDES.Create();
        des3.Key = derivedKey;
        des3.Mode = CipherMode.ECB;
        des3.Padding = PaddingMode.PKCS7;
        var encryptedBytes = Convert.FromBase64String(encryptedPassword);
        using var decryptor = des3.CreateDecryptor();
        var decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        return Encoding.UTF8.GetString(decrypted);
    }
}
