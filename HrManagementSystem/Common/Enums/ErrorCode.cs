namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 1 ,

        CountryNotFound =100,
        CountryHasStates = 101,

        StateNotFound = 200,
 
        StateHasCities =201,

        StateIsExist = 202,


        NoCitiesfound = 300,
        CityAlreadyExistsInThisState = 301 ,

        OrganizationNotExis = 400,

        CompanyNotExist = 500,

        BranchNotExist = 600,

        DepartmentNotExist= 700,

        TeamNotExist = 800,

    }
}
