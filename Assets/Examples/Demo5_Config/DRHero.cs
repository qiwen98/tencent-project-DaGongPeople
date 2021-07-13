using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;
using UnityEngine;

namespace Demo5
{
    public class DRHero : IDataRow
    {
        public int Id { get; protected set; }
        public string Name { get; private set; }
        public int Atk { get; private set; }

        public bool ParseDataRow(string dataRowString, object userData)
        {
            try
            {
                // ＼t是TAB
                string[] text = dataRowString.Split('\t');
                int index = 0;
                index++;
                Id = int.Parse(text[index++]);
                Name = text[index++];
                Atk = int.Parse(text[index++]);
            }
            catch (Exception e)
            {
                Log.Error("DRHero ParseDataRow Error:" + e);
                return false;
            }

            return true;
        }

        public bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            throw new System.NotImplementedException();
        }
    }
}