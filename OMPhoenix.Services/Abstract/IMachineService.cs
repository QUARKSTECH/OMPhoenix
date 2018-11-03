using OMPhoenix.ViewModel;

namespace OMPhoenix.Services.Abstract
{
    public interface IMachineService
    {
        void AddUpdateMachineRecords(MachineViewModel machineVm);
        ResponseViewModel GetAllMachine();
    }
}
