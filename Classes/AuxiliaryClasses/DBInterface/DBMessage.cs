using System.Security.Cryptography;
using System.Text;

namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    ///<summary>
    ///</summary>
    public class DBMessage : Node
    {
        private string private_value;

        ///<summary>
        ///</summary>
        public DBMessage()
        {
            this.Type = "element";
        }

        ///<summary>
        ///</summary>
        public virtual string value
        {
            get { return private_value; }
            set
            {
                private_value = value;
                this.Title = value;
            }
        }

        ///<summary>
        ///</summary>
        public virtual string hash_md5
        {
            get { return getMd5Hash(); }
            set { ; }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public virtual string getMd5Hash()
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(private_value));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (null == obj as DBMessage)
            {
                return false;
            }
            return ((DBMessage) obj).getMd5Hash() == getMd5Hash();
        }

        public override int GetHashCode()
        {
            return 29*this.value.GetHashCode();
        }

    }
}