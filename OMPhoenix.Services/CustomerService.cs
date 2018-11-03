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
    public class CustomerService : ICustomerService
    {
        private readonly IEntityBaseRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IEntityBaseRepository<Customer> customerRepository
            , IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddUpdateCustomerRecords(CustomerViewModel customerVm)
        {
            var customerData = Mapper.Map<CustomerViewModel, Customer>(customerVm);
            _customerRepository.Add(customerData);
            _unitOfWork.Commit();
        }

        public ResponseViewModel GetAllCustomers()
        {
            ResponseViewModel rm = new ResponseViewModel();
            var customerList = _customerRepository.GetAll().ToList();
            var customerData = Mapper.Map<List<Customer>, List<CustomerViewModel>>(customerList);
            rm.responseData = customerData;
            rm.status = 1;
            rm.message = Constants.Retreived;
            return rm;
        }
    }
}
