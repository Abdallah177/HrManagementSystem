namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        //------------ General (0– 99)---------------
        NoError = 1,
        DuplicateRecord = 2,
        ConfiguratioEntityNotFound = 3,

        //--------- Main Entity (100–199)--------------
        OrganizationNotExis = 100,
        OrganizationIDNotFound = 101,
        NoOrganizationFound = 102,
        OrganizationAlreadyExists = 103,

        
        CompanyNotExist = 110,

       
        BranchNotExist = 120,
        CanNotRemoveThisBranch = 121,

       
        DepartmentNotExist = 130,
        DepartmentIsExist = 131,
        DepartmentHasRelatedTeams = 132,

        
        TeamNotExist = 140,
        NoTeamsFound = 141,

        //--------------------Location (200–299)-----------
        CountryNotFound = 200, 
        CountryHasStates = 201,
        CountryHasRelatedCompanies = 202,
        CountryNameIsExist = 203,

       
        StateNotFound = 210, 
        StateIsExist = 211,
        StateHasCities = 212,

       
        NoCitiesfound = 220,
        CityAlreadyExistsInThisState = 221,
        CityNotExist = 222,
        DuplicateCityName = 223,

 

        //--------------Configurations(300–399)----------
        ProbationNotFound = 300,
        ProbationNotExist = 301,

        
        VacationNotFound = 310,
        VacationNotExist = 311,

        RequestNotExist = 320,
        RequestNotFound = 321,

        BreakNotFound = 330,
        NonBreakFound = 331,

        ShiftNotExist=340,
        NonShiftFound,

    }
}
