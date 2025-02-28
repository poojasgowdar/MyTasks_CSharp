using AutoMapper;
using DTOs.DTOs;
using Entities.Entities;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShortLinkService
    {
        private readonly IShortLinkRepository _repository;
        private readonly IMapper _mapper;

        public ShortLinkService(IShortLinkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ShortLinkDTO CreateShortLink(CreateShortLinkDTO request)
        {
            string shortCode = request.CustomAlias ?? Guid.NewGuid().ToString()[..6];
            var newLink = new ShortLink
            {
                ShortCode = shortCode,
                OriginalUrl = request.OriginalUrl,
                CreatedAt = DateTime.UtcNow
            };

            _repository.AddShortLink(newLink);
            return _mapper.Map<ShortLinkDTO>(newLink);
        }

        public ShortLinkDTO GetShortLink(string shortCode)
        {
            var link = _repository.GetByShortCode(shortCode);
            return _mapper.Map<ShortLinkDTO>(link);
        }
        public bool DeleteShortLink(string shortCode)
        {
            var shortLink = _repository.GetByShortCode(shortCode);
            if (shortLink == null)
            {
                return false;
            }

            _repository.DeleteShortLink(shortCode);
            _repository.SaveChanges();
            return true;
        }
        public IEnumerable<ShortLinkDTO> GetAllShortLinks()
        {
            var shortLinks = _repository.GetAllShortLinks();
            return _mapper.Map<IEnumerable<ShortLinkDTO>>(shortLinks);
        }
    }
}
