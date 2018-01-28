using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Videothek.Persistence;
using Videothek.Persistence.Entities;

namespace Videothek.Core
{
    public class VideoService
    {
        private readonly Repository<VideoEntity> _videoRepository;

        public VideoService(Repository<VideoEntity> videoRepository)
        {
            _videoRepository = videoRepository ?? throw new ArgumentNullException();
        }

        public IEnumerable<Video> FetchAllVideos()
        {
            var videoEntities = _videoRepository.Get();
            var videos = Mapper.Map<Video[]>(videoEntities);
            return videos;
        }
    }
}
