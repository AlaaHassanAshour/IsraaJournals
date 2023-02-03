using IsraaJournals.Models;

namespace IsraaJournals.ViewModel
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AppUserVM Auther { get; set; }
        public VolumeVM Volume { get; set; }

        public ArtivalStutas ArtivalStutass { get; set; }
    }
}
