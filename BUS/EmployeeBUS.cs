namespace BUS
{
    public class EmployeeBUS
    {
        public List<DTO.EmployeeDTO> GetAllEmployees()
        {
            return DAO.EmployeeDAO.GetAllEmployees();
        }
    }
}
