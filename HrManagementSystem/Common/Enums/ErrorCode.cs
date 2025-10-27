﻿namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 1 ,

        CountryNotFound =100,


        StateNotFound = 200,

        StateIsExist = 300,

        CountryHasStates = 400,

        NoOrganizationFound = 201,
        NoCitiesfound = 202,
        BranchNotFound = 203,
        DepartmentIsExist = 204,
        CountryHasRelatedCompanies = 205,
        TeamNotExist = 207,
        CityNotExist = 208,
        NoDepartmentsFound = 206
    }
}
