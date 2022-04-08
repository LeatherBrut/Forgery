﻿using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Providers.Processors;

namespace Forgery.BspEditor.Tools
{
    [Export(typeof(IBspSourceProcessor))]
    public class ToolProcessor : IBspSourceProcessor
    {
        public string OrderHint => "B";

        public async Task AfterLoad(MapDocument document)
        {
            if (!document.Map.Data.Any(x => x is ActiveTexture))
            {
                var tc = await document.Environment.GetTextureCollection();
                var first = tc.GetBrowsableTextures()
                    .OrderBy(t => t, StringComparer.CurrentCultureIgnoreCase)
                    .Where(item => item.Length > 0)
                    .Select(item => new { item, c = Char.ToLower(item[0]) })
                    .Where(t => t.c >= 'a' && t.c <= 'z')
                    .Select(t => t.item)
                    .FirstOrDefault();
                document.Map.Data.Add(new ActiveTexture { Name = first });
            }
        }

        public Task BeforeSave(MapDocument document)
        {
            return Task.FromResult(0);
        }
    }
}