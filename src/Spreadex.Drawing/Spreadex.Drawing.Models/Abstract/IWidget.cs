using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.Models.Abstract;

public interface IWidget
{
    string TypeName { get; }
    PageLocation Location { get; }
    string GetDetails();
}
