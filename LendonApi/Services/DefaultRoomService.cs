using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IConfigurationProvider _mappingConfiguration;
        public DefaultRoomService(HotelApiDbContext context, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            _context = context;
            _mappingConfiguration = configurationProvider;
        }
        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = _context.Rooms.SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Room>(entity);          
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var query = _context.Rooms
                .ProjectTo<Room>(_mappingConfiguration);

            return query.ToArray();
        }
    }
}
