﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZauberCMS.Core.Content.Commands;
using ZauberCMS.Core.Data;

namespace ZauberCMS.Core.Content.Handlers;

public class GetContentBySlugHandler(IServiceProvider serviceProvider)
    : IRequestHandler<GetContentBySlugCommand, Models.Content?>
{
    public async Task<Models.Content?> Handle(GetContentBySlugCommand request, CancellationToken cancellationToken)
    {
        //  Do we need to sanitize and check slug? Or will EF core parameter query deal with it?
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ZauberDbContext>();

        // If this is root content, get the first one with minimal data
        var content = request.IsRootContent
            ? await dbContext.Contents
                .AsNoTracking()
                .Include(x => x.ContentType)
                .Where(c => c.IsRootContent && c.Published)
                .Select(c => new { c.Id, c.InternalRedirectId, c.ContentType!.IncludeChildren })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            : await dbContext.Contents
                .AsNoTracking()
                .Include(x => x.ContentType)
                .Where(c => c.Url == request.Slug && c.Published)
                .Select(c => new { c.Id, c.InternalRedirectId, c.ContentType!.IncludeChildren })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        // If this content has an internal redirect id, get that content's ID instead
        if (content?.InternalRedirectId != null && content.InternalRedirectId != Guid.Empty && !request.IgnoreInternalRedirect)
        {
            var internalRedirectIdValue = content.InternalRedirectId.Value;
            content = await dbContext.Contents
                .AsNoTracking()
                .Include(x => x.ContentType)
                .Where(c => c.Id == internalRedirectIdValue)
                .Select(c => new { c.Id, c.InternalRedirectId, c.ContentType!.IncludeChildren })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        if (content == null)
        {
            return null;
        }

        // Now we perform the more expensive query to fetch the content with includes
        var query = dbContext.Contents
            .AsNoTracking()
            .Include(x => x.PropertyData)
            .Include(x => x.Parent)
            .Include(x => x.ContentType)
            .AsSplitQuery()
            .AsQueryable();

        if (request.IncludeChildren || content.IncludeChildren)
        {
            query = query.Include(x => x.Children);
        }

        var fullContent = await query
            .FirstOrDefaultAsync(c => c.Id == content.Id, cancellationToken: cancellationToken);

        return fullContent;
    }
}