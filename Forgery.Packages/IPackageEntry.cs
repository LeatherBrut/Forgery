using System.IO;

namespace Forgery.Packages
{
    public interface IPackageEntry
    {
        string Name { get; }
        string FullName { get; }
        string ParentPath { get; }
        long Length { get; }
        Stream Open();
    }
}