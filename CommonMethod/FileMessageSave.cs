﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod
{
    public class FileMessageSave
    {
        public static bool MessageSave(string str)
        {
            File.AppendAllText("c:\\weixin.txt", str);
            return true;
        }
    }
}