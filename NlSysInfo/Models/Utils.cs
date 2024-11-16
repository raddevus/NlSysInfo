
using System.Security.Cryptography;
using System.Text;

namespace NewLibre;

public class Utils{
    public static string GenSha256(string value) 
    { 
        var sha = SHA256.Create(); 
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(value));
        return BytesToHex(hash).ToLower(); 
    } 

    public static string BytesToHex(byte[] bytes) 
    { 
        return String.Concat(Array.ConvertAll(bytes, x => x.ToString("X2"))); 
    }

    public static String GenSha256(byte[] allFileBytes ){
        var sha = SHA256.Create(); 
        byte[] hash = sha.ComputeHash(allFileBytes);
        return BytesToHex(hash).ToLower(); 
    }

}