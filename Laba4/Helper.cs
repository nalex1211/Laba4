using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;

namespace Laba4
{
    internal class Helper
    {
        public List<Info> getDataFromJson(string path)
        {
            var content = File.ReadAllText(path);
            var query = JsonSerializer.Deserialize<List<Info>>(content);
            return query;
        }

        public void writeDataToJSON(string path, List<Info> list)
        {
            var query = JsonSerializer.Serialize(list, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(path, query);
        }

        public List<Info> orderBy(string choice, List<Info> list)
        {
            switch (choice)
            {
                case "Name":
                return list.OrderBy(x => x.Name).ToList();

                case "Middle name":
                return list.OrderBy(x => x.MiddleName).ToList();

                case "Last name":
                return list.OrderBy(x => x.LastName).ToList();

                case "Departament":
                return list.OrderBy(x => x.Departament).ToList();

                case "Faculty":
                return list.OrderBy(x => x.Faculty).ToList();

                case "Date of birth":
                return list.OrderBy(x => x.DateOfBirth).ToList();
            }
            return list;
        }

        public List<Info> searchBy(string choice, string searchedObject, List<Info> list)
        {
            switch (choice)
            {
                case "Name":
                return list.Where(x => x.Name == searchedObject).ToList();

                case "Middle name":
                return list.Where(x => x.MiddleName == searchedObject).ToList();

                case "Last name":
                return list.Where(x => x.LastName == searchedObject).ToList();

                case "Departament":
                return list.Where(x => x.Departament == searchedObject).ToList();

                case "Faculty":
                return list.Where(x => x.Faculty == searchedObject).ToList();

                case "Date of birth":
                return list.Where(x => x.DateOfBirth == searchedObject).ToList();
            }
            
            return list;
        }
    }
}
