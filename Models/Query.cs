using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabaOne.Models
{
    public class Query
    {
        public int countryNamesCount { get; set; }
        public int variantNamesCount { get; set; }
        public string QueryId { get; set; }
        public string countryId { get; set; }
        public string symptomId{ get; set; }
        public string variantId { get; set; }
        public string virusId { get; set; }

        public string Error { get; set; }

        public int ErrorFlag { get; set; }

        //public string DevName { get; set; }

        public string CountryName { get; set; }
        public string SymptomName { get; set; }

        public string VariantName { get; set; }
        public string VirusName { get; set; }
        public string GroupName { get; set; }


        public List<string> GroupNames { get; set; }
        public List<string> VariantNames { get; set; }
        public List<string> VirusNamesByGroup { get; set; }
        public List<Virus> VirusNames { get; set; }
        public List<string> CountryNames { get; set; }
        public List<string> SymptomNames { get; set; }
    }
}
