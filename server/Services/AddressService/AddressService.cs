using System.Collections.Generic;
using AutoMapper;
using server.DataAccess.Repositories.AddressRepo;
using server.Dtos.AddressDto;
using server.Models;

namespace Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public AddressReadDto AddNewAddress(AddressCreateDto addressCreateDto)
        {
            var newAddressModel = this._mapper.Map<Address>(addressCreateDto);

            this._repository.Add(newAddressModel);
            this._repository.SaveChanges();

            var addressReadDto = this._mapper.Map<AddressReadDto>(newAddressModel);

            return addressReadDto;
        }

        public bool DeleteAddress(int id)
        {
            Address existingAddress = this._repository.GetById(id);
            if (existingAddress == null) return false;

            try
            {
                this._repository.Remove(existingAddress);
                this._repository.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public AddressReadDto GetAddressById(int id)
        {
            Address address = this._repository.GetById(id);
            if (address == null) return null;

            var addressReadDto = this._mapper.Map<AddressReadDto>(address);
            return addressReadDto;
        }

        public IEnumerable<AddressReadDto> GetAllAddressByUserId(int id)
        {
            var addresses = this._repository.GetAllAddressesByUserId(id);
            if (addresses == null) return null;

            var addressReadDtos = this._mapper.Map<IEnumerable<AddressReadDto>>(addresses);

            return addressReadDtos;
        }

        public bool UpdateAddress(int id, AddressUpdateDto addressUpdateDto)
        {
            Address existingAddress = this._repository.GetById(id);
            if (existingAddress == null) return false;

            this._mapper.Map(addressUpdateDto, existingAddress);

            this._repository.Update(existingAddress);
            this._repository.SaveChanges();

            return true;
        }
    }
}