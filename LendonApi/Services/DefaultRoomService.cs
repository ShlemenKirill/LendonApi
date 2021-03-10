using AutoMapper;
using LendonApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LendonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext _context;
        private readonly IMapper _mapper;
        public DefaultRoomService(HotelApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = _context.Rooms.SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Room>(entity);          
        }
    }
}
