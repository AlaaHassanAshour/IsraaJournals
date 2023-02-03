namespace IsraaJournals.ViewModel
{
    public class VolumeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JournalVM Journal { get; set; }
        public DateTime insertDate { get; set; }
    }
}
