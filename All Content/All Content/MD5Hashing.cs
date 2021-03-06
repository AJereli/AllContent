﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace All_Content
{
    class MD5Hashing
    {
        static MD5 md5_hash;

        public MD5Hashing()
        {
            md5_hash = MD5.Create();
        }
        /// <summary>
        /// Determinate MD5 hash from input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a hash of your string</returns>
        static public string GetMd5Hash(string input)
        {
            byte[] data = md5_hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            string ans = "";
            for (int i = 0; i < data.Length; i++)
                ans += data[i].ToString("x2");
            return ans;
        }

        /// <summary>
        /// It compares two hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <param name="isInputHashed">Set true if input - not hased string</param>
        /// <returns></returns>
        static public bool CompareHashes (string input, string hash, bool isInputHashed = false)
        {
            if (isInputHashed)
                return GetMd5Hash(input) == hash;
            else
                return input == hash;
        }
        
    }
}
