using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCTutorial.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }

        [DisplayName("Genre")]
        public virtual int GenreId { get; set; }

        [DisplayName("Artist")]
        public virtual int ArtistId { get; set; }

        [Remote("CheckTitle", "StoreManager",AdditionalFields = "AlbumId", ErrorMessage = "The entered {0} already exists in the system.")]
        [StringLength(100)]
        [DisplayName("Album Title")]
        public virtual string Title { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Album Description")]
        [MaxWords(2, ErrorMessage = "Too Many word in {0}.")]
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
