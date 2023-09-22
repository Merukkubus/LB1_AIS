using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ЛБ1.Reader;

namespace ЛБ1
{
    public class Controller
    {
        public Controller()
        {
            Reader model = new();
            List<Reader> readers = new List<Reader>();
        }
        static void Main(string[] args)
        {
            View view = new();
            while (true)
            {

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                    default:
                        Console.Clear();
                        view.Menu();
                        break;
                }
            }
        }
        char Delimiter = ',';
        StringBuilder scv = new StringBuilder();
        List<Reader> readers = new List<Reader>();
        public void Add(string path) //case 2
        {
            scv.Clear();
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
        public void ClearList()
        {
            readers.Clear();
        }
        public void AddToList(string path)
        {
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
        public void AddToFile(string path, int num)
        {
            for (int i = 0; i < num; i++)
            {
                string user = Convert.ToString(Console.ReadLine());
                string[] users = user.Split(new char[] { Delimiter });
                readers.Add(new Reader(Convert.ToInt32(users[0]), users[1], users[2],
                    Convert.ToInt32(users[3]), Convert.ToBoolean(users[4])));
            }
            scv.Clear();
            for (int i = 0; i < num; i++)
            {
                scv.AppendLine(readers[i].id + Delimiter.ToString() + readers[i].name + Delimiter.ToString() + readers[i].surname + Delimiter.ToString()
                    + readers[i].semester + Delimiter.ToString() + readers[i].scholarship);
            }
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.Write(scv.ToString());
            }
        }
    }
}