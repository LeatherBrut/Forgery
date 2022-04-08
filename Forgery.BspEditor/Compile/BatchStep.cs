using System.Threading.Tasks;
using Forgery.BspEditor.Documents;

namespace Forgery.BspEditor.Compile
{
    /// <summary>
    /// A step to run as part of a batch
    /// </summary>
    public abstract class BatchStep
    {
        public abstract BatchStepType StepType { get; }
        public abstract Task Run(Batch batch, MapDocument document);
    }
}