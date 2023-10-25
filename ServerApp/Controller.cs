using System.Collections.Generic;
using System.IO;
using System;
using System.Text;

namespace ServerApp
{
    public class Controller
    {
        char Delimiter = ',';
        StringBuilder scv = new StringBuilder();
        List<Reader> readers = new List<Reader>();
        public string GetAll(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
        public void ClearList()
        {
            readers.Clear();
        }
        public void AddToList(string path)
        {
            ClearList();
            using (StreamReader rd = new StreamReader(path))
            {
                while (!rd.EndOfStream)
                {
                    string str = rd.ReadLine();
                    string[] onestr = str.Split(new char[] { Delimiter });
                    if (onestr.Length != 5) { continue; }
                    readers.Add(new Reader(Convert.ToInt32(onestr[0]), onestr[1], onestr[2],
                   Convert.ToInt32(onestr[3]), Convert.ToBoolean(onestr[4])));
                }
            }
        }
        public string GetSeparate(string path, int num)
        {
            ClearList();
            AddToList(path);
            return readers[num].GetLine();
        }
        public void Delete(string path, int num)
        {
            scv.Clear();
            AddToList(path);
            readers.RemoveAt(num);
            for (int i = 0; i < readers.Count; i++)
            {
                scv.AppendLine(readers[i].id + Delimiter.ToString() + readers[i].name + Delimiter.ToString() + readers[i].surname + Delimiter.ToString()
                + readers[i].semester + Delimiter.ToString() + readers[i].scholarship);
            }
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(scv.ToString());
            }
        }
        public void AddToFile(string path, string user)
        {
            ClearList();
            string[] users = user.Split(new char[] { Delimiter });
            readers.Add(new Reader(Convert.ToInt32(users[0]), users[1], users[2],
                Convert.ToInt32(users[3]), Convert.ToBoolean(users[4])));
            scv.Clear();
            scv.AppendLine(readers[0].id + Delimiter.ToString() + readers[0].name + Delimiter.ToString() + readers[0].surname + Delimiter.ToString()
                + readers[0].semester + Delimiter.ToString() + readers[0].scholarship);
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.Write(scv.ToString());
            }
        }
        public void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
    }
}