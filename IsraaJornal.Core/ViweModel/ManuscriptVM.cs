using IsraaJournals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraaJornal.Core.ViweModel
{
    public class ManuscriptVM
    {
        public Article Article { get; set; }
        public RecarcheType RecarcheType { get; set; }
        public Section Section { get; set; }
        public Journal Journal { get; set; }
        public string title { get; set; }
        public string Abstract { get; set; }
        public string Keyword { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfAuthor { get; set; }
        public List<Author> Authors { get; set; }
        public List<ExcludeReviwer> ExcludeReviwers { get; set; }
        public List<SuggestReivewr> SuggestReivewrs { get; set; }
    }
}
