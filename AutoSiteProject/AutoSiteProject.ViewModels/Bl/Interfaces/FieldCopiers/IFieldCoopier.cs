
namespace AutoSiteProject.Models.Bl.Interfaces.FieldCopiers
{
    public interface IFieldCoopier<TFr, TTo>
    {
        TTo CopyFields(TFr from, TTo to);
        TFr CopyFields(TTo from, TFr to);
    }
}
