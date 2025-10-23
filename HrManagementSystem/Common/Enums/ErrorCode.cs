namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 1 ,

        CountryNotFound =100,
        CountryHasStates = 101,

        StateNotFound = 200,
<<<<<<< HEAD
        StateHasCities =201,
=======
        StateIsExist = 201,
>>>>>>> 4d9c389c5ebc0298735dec7d3cd5819b9767e6af

        NoCitiesfound = 300,
        CityAlreadyExistsInThisState = 301 ,

        OrganizationNotExis = 400,

        CompanyNotExist = 500,

        BranchNotExist = 600,

        DepartmentNotExist= 700,

        TeamNotExist = 800,

    }
}
