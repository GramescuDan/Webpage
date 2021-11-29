using System.ComponentModel.DataAnnotations.Schema;

namespace WebPage.Domain.Abstractions
{
    public abstract class AbstractModel
    {
        public string Id { get; set; }
    }
}