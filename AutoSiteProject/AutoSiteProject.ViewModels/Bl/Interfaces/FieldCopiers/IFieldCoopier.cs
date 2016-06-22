
namespace AutoSiteProject.Models.Bl.Interfaces.FieldCopiers
{
    public interface IFieldCoopier<FR, TO>
    {
        TO CopyFields(FR from, TO to);
        FR CopyFields(TO from, FR to);
    }
}
