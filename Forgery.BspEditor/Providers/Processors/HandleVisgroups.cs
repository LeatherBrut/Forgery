﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;

namespace Forgery.BspEditor.Providers.Processors
{
    /// <summary>
    /// Populates visgroup object lists and visibilities during map load
    /// </summary>
    [Export(typeof(IBspSourceProcessor))]
    public class HandleVisgroups : IBspSourceProcessor
    {
        public string OrderHint => "C";

        public Task AfterLoad(MapDocument document)
        {
            var allObjects = document.Map.Root.FindAll();

            // add objects in each group to the visgroup list
            var visgroups = document.Map.Data.Get<Visgroup>().ToDictionary(x => x.ID, x => x);
            foreach (var obj in allObjects)
            {
                var ids = obj.Data.Get<VisgroupID>().ToList();
                var visible = true;
                foreach (var id in ids)
                {
                    if (!visgroups.ContainsKey(id.ID)) continue;

                    var vis = visgroups[id.ID];
                    vis.Objects.Add(obj);
                    visible = vis.Visible;
                }
                
                // hide objects in hidden visgroups
                obj.Data.Replace(new VisgroupHidden(!visible));
            }

            // set up auto visgroups
            var autoVis = document.Environment?.GetAutomaticVisgroups()?.ToList() ?? new List<AutomaticVisgroup>();

            foreach (var av in autoVis)
            {
                document.Map.Data.Add(av);
                foreach (var obj in allObjects)
                {
                    if (av.IsMatch(obj))
                    {
                        av.Objects.Add(obj);
                    }
                }
            }


            return Task.FromResult(0);
        }

        public Task BeforeSave(MapDocument document)
        {
            return Task.FromResult(0);
        }
    }
}