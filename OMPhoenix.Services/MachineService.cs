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
    public class MachineService : IMachineService
    {
        private readonly IEntityBaseRepository<Machine> _machineRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MachineService(IEntityBaseRepository<Machine> machineRepository
            , IUnitOfWork unitOfWork)
        {
            _machineRepository = machineRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddUpdateMachineRecords(MachineViewModel machineVm)
        {
            var machineData = Mapper.Map<MachineViewModel, Machine>(machineVm);
            _machineRepository.Add(machineData);
            _unitOfWork.Commit();
        }

        public ResponseViewModel GetAllMachine()
        {
            ResponseViewModel rm = new ResponseViewModel();
            var machineList = _machineRepository.GetAll().ToList();
            var machineData = Mapper.Map<List<Machine>, List<MachineViewModel>>(machineList);
            rm.responseData = machineData;
            rm.status = 1;
            rm.message = Constants.Retreived;
            return rm;
        }
    }
}
