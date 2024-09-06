﻿using LiskovSubstitutionPrincipleDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO.Enumeration;

namespace LiskovSubstitutionPrincipleDemo.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("Data/BookStore.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }
        internal static List<Book> ReadData(string extra)
        {
            List<Book> books = ReadData();
            var filename = "Data/BookStore2.json";
            var cadJSON = ReadFile(filename);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            if (extra == "topic")
            {
                filename = "Data/BookStore3.json";
                cadJSON = ReadFile(filename);
                books.AddRange(JsonConvert.DeserializeObject<List<TopicBook>>(cadJSON));
            }
            return books;
        }
    }
}
