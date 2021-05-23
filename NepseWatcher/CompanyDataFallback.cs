using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NepseWatcher
{
    public static class CompanyDataFallback
    {
        public static List<Company> GetCompanies()
        {
            List<Company> companyList = new List<Company>();

            using (StreamReader stream = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("NepseWatcher.Companies.txt")))
            {
                string content = stream.ReadToEnd();
                string[] entries = content.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < entries.Length; i++)
                {
                    string entry = entries[i];
                    string[] fields = entry.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    string name = fields[1];
                    string sector = fields[2];

                    string fullName = name.Substring(0, name.LastIndexOf('(')).Trim();
                    string symbol = name.Replace(fullName, "").Replace("(", "").Replace(")", "").Trim();
                    if (symbol == "") //if empty, skip it
                        continue;
                    if (symbol.Any(letter => (char.IsDigit(letter) ? false : !char.IsUpper(letter)))) //if the symbol contains any non-capital letter, it's probably a mistake, so skip it
                        continue;

                    companyList.Add(new Company(symbol, fullName, sector));
                }
            }

            return companyList;
        }
    }
}
