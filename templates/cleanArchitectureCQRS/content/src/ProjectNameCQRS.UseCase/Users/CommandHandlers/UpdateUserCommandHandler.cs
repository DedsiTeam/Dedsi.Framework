﻿using Dedsi.Ddd.CQRS.CommandHandlers;
using ProjectNameCQRS.Repositories.Users;
using ProjectNameCQRS.Users.Commands;
using Volo.Abp;

namespace ProjectNameCQRS.Users.CommandHandlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : DedsiCommandHandler<UpdateUserCommand, bool>
{
    public override async Task<bool> HandleEventAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(a => a.Id == command.id);
        if (user == null)
        {
            throw new UserFriendlyException("数据不存在！");
        }
        user.Update(command.UserName,command.Account,command.Email);

        await userRepository.UpdateAsync(user);

        return true;
    }
}