using OMPhoenix.ViewModel;

namespace OMPhoenix.Services.Abstract
{
    public interface ICustomerService
    {
        void AddUpdateCustomerRecords(CustomerViewModel customerVm);
        ResponseViewModel GetAllCustomers();
    }
}
