using System.Web;

namespace AutoSiteProject.Models.ViewModels
{
    public class CarImageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
