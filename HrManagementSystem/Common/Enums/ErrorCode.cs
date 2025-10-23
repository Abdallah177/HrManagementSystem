namespace HrManagementSystem.Common.Enums
{
    public enum ErrorCode
    {
        NoError = 1 ,

        CountryNotFound =100,


        StateNotFound = 200,
        StateHasCities =201,

        StateIsExist = 300,

        CountryHasStates = 400,
    }
}
