﻿using MediatR;
using ZauberCMS.Core.Shared.Models;

namespace ZauberCMS.Core.Content.Commands;

public class SaveContentCommand : IRequest<HandlerResult<Models.Content>>
{
    public Models.Content? Content { get; set; }
}