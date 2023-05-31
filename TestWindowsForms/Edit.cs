using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestWindowsForms
{
    public partial class Edit
    {
        static public byte[] key = {(byte)0xCA, (byte)0xFE, (byte)0xBA, (byte)0xBE, (byte)0xDE, (byte)0xAD,
            (byte)0xBE, (byte)0xAF, (byte)0x00, (byte)0x00, (byte)0x01, (byte)0x02, (byte)0x03, (byte)0x04, (byte)0x05, (byte)0x06 };
        static public int numberOfQuestionL1 = 5;
        static public int numberOfQuestionL2 = 5;
        static public int SUCCESSFUL = 14;
        static public int GOOD = 12;
        static public int NORMAL = 9;
        ObjectSettings settings;
        Serializ questions;

        public Edit(MainForm start)
        {
            DecryptFile(@"Json\Config.json", key);
            DecryptFile(@"Json\Question.json", key);
            settings = JsonConvert.DeserializeObject<ObjectSettings>(OpenJsonFile(@"Json\Config.json"));
            questions = JsonConvert.DeserializeObject<Serializ>(OpenJsonFile(@"Json\Question.json"));
            EncryptFile(@"Json\Config.json", key);
            EncryptFile(@"Json\Question.json", key);

            numberOfQuestionL1 = settings.NumberQuestion1;
            numberOfQuestionL2 = settings.NumberQuestion2;
            SUCCESSFUL = settings.SUCCESSFUL;
            GOOD = settings.GOOD;
            NORMAL = settings.NORMAL;
        }

        public string OpenJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("test");
                    }
                }
                catch (Exception e)
                {
                }
            }
            return File.ReadAllText(path);
        }

        public static void EncryptFile(string path, byte[] key)
        {
            string tmpPath = Path.GetTempFileName();
            using (FileStream fsSrc = File.OpenRead(path))
            using (AesManaged aes = new AesManaged() { Key = key })
            using (FileStream fsDst = File.Create(tmpPath))
            {
                fsDst.Write(aes.IV);
                using (CryptoStream cs = new CryptoStream(fsDst, aes.CreateEncryptor(), CryptoStreamMode.Write, true))
                {
                    fsSrc.CopyTo(cs);
                }
            }
            File.Delete(path);
            File.Move(tmpPath, path);
        }

        public static void DecryptFile(string path, byte[] key)
        {
            string tmpPath = Path.GetTempFileName();
            using (FileStream fsSrc = File.OpenRead(path))
            {
                byte[] iv = new byte[16];
                fsSrc.Read(iv);
                using (AesManaged aes = new AesManaged() { Key = key, IV = iv })
                using (CryptoStream cs = new CryptoStream(fsSrc, aes.CreateDecryptor(), CryptoStreamMode.Read, true))
                using (FileStream fsDst = File.Create(tmpPath))
                {
                    cs.CopyTo(fsDst);
                }
            }
            File.Delete(path);
            File.Move(tmpPath, path);
        }

        public static string DecryptData (string path)
        {
            string outString = "";
            string tmpPath = Path.GetTempFileName();
            using (FileStream fsSrc = File.OpenRead(path))
            {
                byte[] iv = new byte[16];
                fsSrc.Read(iv);
                using (AesManaged aes = new AesManaged() { Key = key, IV = iv })
                using (CryptoStream cs = new CryptoStream(fsSrc, aes.CreateDecryptor(), CryptoStreamMode.Read, true))
                using (StreamReader srDecrypt = new StreamReader(cs))
                {
                    outString = srDecrypt.ReadToEnd();
                }
            }
            return outString;
        }
    }
}