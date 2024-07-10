﻿using System.Linq.Dynamic.Core;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZauberCMS.Core.Data;
using ZauberCMS.Core.Extensions;
using ZauberCMS.Core.Media.Commands;
using ZauberCMS.Core.Providers;
using ZauberCMS.Core.Shared;
using ZauberCMS.Core.Shared.Models;

namespace ZauberCMS.Core.Media.Handlers;

public class DeleteMediaHandler(IServiceProvider serviceProvider, 
    AppState appState, 
    AuthenticationStateProvider authenticationStateProvider,
    ProviderService providerService) 
    : IRequestHandler<DeleteMediaCommand, HandlerResult<Models.Media>>
{
    public async Task<HandlerResult<Models.Media>> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ZauberDbContext>();
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var handlerResult = new HandlerResult<Models.Media>();
        
        var media = dbContext.Medias.FirstOrDefault(x => x.Id == request.MediaId);
        if (media != null)
        {
            //Check if it has children
            var children = dbContext.Medias.AsNoTracking().Where(x => x.ParentId == media.Id);
            if (children.Any())
            {
                handlerResult.AddMessage("Unable to delete media with child content, delete or move those items first", ResultMessageType.Error);
                return handlerResult;
            }

            
            var filePathToDelete = media.Url;
            dbContext.Medias.Remove(media);
            await appState.NotifyMediaDeleted(null, authState.User.Identity?.Name!);
            var result = await dbContext.SaveChangesAndLog(media, handlerResult, cancellationToken);
            if (result.Success && request.DeleteFile)
            {
                await providerService.StorageProvider!.DeleteFile(filePathToDelete);
            }

            return result;
        }

        handlerResult.AddMessage("Unable to delete, as no Media with that id exists", ResultMessageType.Warning);
        return handlerResult;
    }
}