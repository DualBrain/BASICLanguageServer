﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using BASICLanguageServer;
using JsonRpc.Server;
using LanguageServer.Contracts;
using LanguageServer.Contracts.Client;
using LanguageServer.Server;

namespace BASICLanguageServer.Services
{
    public class BASICLanguageServiceBase : JsonRpcService
    {

        protected LanguageServerSession Session => RequestContext.Features.Get<LanguageServerSession>();

        protected ClientProxy Client => Session.Client;

        protected TextDocument GetDocument(Uri uri)
        {
            if (Session.Documents.TryGetValue(uri, out var sd))
                return sd.Document;
            return null;
        }

        protected TextDocument GetDocument(TextDocumentIdentifier id) => GetDocument(id.Uri);

    }
}
