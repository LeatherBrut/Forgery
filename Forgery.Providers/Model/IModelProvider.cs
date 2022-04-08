using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forgery.FileSystem;
using Forgery.Rendering.Interfaces;

namespace Forgery.Providers.Model
{
    public interface IModelProvider
    {
        bool CanLoadModel(IFile file);
        Task<IModel> LoadModel(IFile file);

        bool IsProvider(IModel model);
        IModelRenderable CreateRenderable(IModel model);
    }
}
