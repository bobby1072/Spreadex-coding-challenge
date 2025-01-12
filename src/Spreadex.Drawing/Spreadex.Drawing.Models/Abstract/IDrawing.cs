namespace Spreadex.Drawing.Models.Abstract;

public interface IDrawing
{
    void AddWidget(IWidget widget);
    void PrintDrawing();
}