using AutoMapper;
using IsraaJournals.DTOs;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;

namespace IsraaJournals
{
    public class AutoMapeerProfile:Profile
    {
        public AutoMapeerProfile()
        {
            CreateMap<Article, ArticleVM>();
            CreateMap<ArticleDTO, Article>();
           // CreateMap<Journal, JournalVM>();
            CreateMap<JournalDTO, Journal>();
            CreateMap<VolumeDTO, Volume>();

        }
    }
}
