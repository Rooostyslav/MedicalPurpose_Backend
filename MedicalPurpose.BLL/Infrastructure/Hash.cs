using System.Security.Cryptography;
using System.Text;

namespace MedicalPurpose.BLL.Infrastructure
{
	public static class Hash
	{
        public static string CreateMD5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] textBytes = Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(textBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
