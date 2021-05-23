using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;
using System.Linq;

namespace NepseWatcher
{
    public class CompaniesInfo
    {
        List<Company> companyList;
        public CompaniesInfo()
        {
            try
            {
                this.companyList = new List<Company>();

                //try extracting company info from the web
                string url = "https://www.nepalipaisa.com/Listed-Companies.aspx";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                HtmlNode table = doc.DocumentNode.SelectNodes("//*[@id='tblListedCompanies']")[0];
                HtmlNode tbody = table.Element("tbody");
                var rows = tbody.Elements("tr");
                foreach (var row in rows)
                {
                    //throw new Exception();
                    List<HtmlNode> cols = row.Elements("td").ToList();
                    HtmlNode nameCol = cols[1];
                    HtmlNode nameLabel = nameCol.Element("label");
                    string entry = nameLabel.Element("a").InnerText;
                    string fullName = entry.Substring(0, entry.LastIndexOf('(')).Trim();
                    string symbol = entry.Replace(fullName, "").Replace("(", "").Replace(")", "").Trim();
                    if (symbol == "") //if empty, skip it
                        continue;
                    if (symbol.Any(letter => (char.IsDigit(letter) ? false : !char.IsUpper(letter)))) //if the symbol contains any non-capital letter, it's probably a mistake, so skip it
                        continue;
                    HtmlNode sectorCol = cols[2];
                    string sector = sectorCol.Element("label").InnerText;

                    this.companyList.Add(new Company(symbol, fullName, sector));
                }
            }
            catch (Exception ex)
            {
                //if extraction from web doesn't work, fallback to hardcoded info
                this.companyList.Clear();
                this.companyList = CompanyDataFallback.GetCompanies();
            }

        }

        public List<Company> CompanyList
        {
            get
            {
                return this.companyList;
            }
        }
    }

    public class Company 
    {
        public string Symbol { get; set; }
        public string Fullname { get; set; }
        public string Sector { get; set; }

        public Company(string symbol, string fullName, string sector)
        {
            this.Symbol = symbol;
            this.Fullname = fullName;
            this.Sector = sector;
        }
    }
}
