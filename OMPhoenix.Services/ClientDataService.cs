using AutoMapper;
using OMPhoenix.Data.Infrastructure;
using OMPhoenix.Data.Repositories;
using OMPhoenix.Entity;
using OMPhoenix.Services.Abstract;
using OMPhoenix.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace OMPhoenix.Services
{
    public class ClientDataService :IClientDataService
    {
        private readonly IEntityBaseRepository<ClientDetail> _clientDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientDataService(IEntityBaseRepository<ClientDetail> clientDetailRepository
            , IUnitOfWork unitOfWork)
        {
            _clientDetailRepository = clientDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddUpdateStudentRecords(ClientDetailViewModel clientDataVm)
        {
            var ClientData = Mapper.Map<ClientDetailViewModel, ClientDetail>(clientDataVm);
            _clientDetailRepository.Add(ClientData);
            _unitOfWork.Commit();

        }

        public ResponseViewModel GetAllStudents()
        {
            ResponseViewModel rm = new ResponseViewModel();
            var clientList = _clientDetailRepository.GetAll().ToList();
            var ClientData = Mapper.Map<List<ClientDetail>, List<ClientDetailViewModel>>(clientList);
            rm.responseData = ClientData;
            rm.status = 1;
            rm.message = Constants.Retreived;
            return rm;

        }
    }
}
