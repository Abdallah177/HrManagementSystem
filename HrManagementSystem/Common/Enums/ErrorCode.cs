namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 1 ,
        DuplicateRecord= 2 ,

        CountryNotFound =100,
        CountryHasStates = 101,
        CountryHasRelatedCompanies = 102,
        CountryNameIsExist = 103,

        StateNotFound = 200,
        StateIsExist = 201,

        NoCitiesfound = 300,
        CityAlreadyExistsInThisState = 301 ,
        CityNotExist = 302,
        DuplicateCityName = 303,

        OrganizationNotExis = 400,
        NoOrganizationFound = 401,
        OrganizationIDNotFound =402,
        OrganizationAlreadyExists=403,

        CompanyNotExist = 500,

        BranchNotExist = 600,
        CanNotRemoveThisBranch = 601,

        DepartmentNotExist = 700,
        DepartmentIsExist = 701,
        DepartmentHasRelatedTeams = 702,

        StateHasCities =201,

        TeamNotExist = 800,
        NoTeamsFound = 801,

    }
}
