using Data.Models.User;
using Domain.Models.User;

namespace Application.Services.Extensions.ModelMappers;

public static class UserMapperExtension
{
    public static UserModel ToModel(this UpsertUserRequest upsertUserRequest)
    {
        return new UserModel
        {
            Name = upsertUserRequest.UserName,
            LicensePlate = upsertUserRequest.LicensePlate
        };
    }

    public static UserDto ToDto(this UserModel userModel)
    {
        return new UserDto(
            userModel.ExternalId, 
            userModel.Name, 
            userModel.LicensePlate);
    }
}