using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class ArtistAdd
    {
        public ArtistAdd()
        {
            BirthOrStartDate = DateTime.Now.AddYears(-25);
        }
        [Required, StringLength(200)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        [Display(Name = "Artist photo")]
        public string UrlArtist { get; set; }
        [StringLength(200)]
        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }
        //public MediaItemBase MediaItems { get; set; }
    }
    public class ArtistAddForm : ArtistAdd
    {
        public int Id { get; set; }
        public SelectList GenreList { get; set; }
    }
    public class ArtistBase : ArtistAdd
    {
        public ArtistBase()
        {
            AlbumIds = new List<int>();
        }
        public int Id { get; set; }
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }
        [Display(Name = "Number of albums")]
        public int AlbumsCount { get; set; }
        public IEnumerable<int> AlbumIds { get; set; }
    }
    public class ArtistWithDetails : ArtistBase
    {
        [Display(Name = "Albums of this Artist")]
        public IEnumerable<AlbumBase> Albums { get; set; }
    }
    /////////////////////////////////////////////////////////////////////
    public class AlbumAdd
    {
        public AlbumAdd()
        {
            ReleaseDate = DateTime.Now;
            ArtistIds = new List<int>();
            TrackIds = new List<int>();
        }
        [Required, StringLength(200)]
        [Display(Name = "Album name")]
        public string Name { get; set; }
        [Display(Name = "Release date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Album image (cover art)")]
        public string UrlAlbum { get; set; }
        [StringLength(200)]
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public ArtistWithDetails CurrentArtist { get; set; }
        public IEnumerable<int> ArtistIds { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
    }
    public class AlbumAddForm
    {
        public AlbumAddForm()
        {
            ReleaseDate = DateTime.Now;
            ArtistIds = new List<int>();
            TrackIds = new List<int>();
        }
        [Required, StringLength(200)]
        [Display(Name = "Album name")]
        public string Name { get; set; }
        [Display(Name = "Release date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Album image (cover art)")]
        public string UrlAlbum { get; set; }
        [StringLength(200)]
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public IEnumerable<int> ArtistIds { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public int Id { get; set; }
        public SelectList GenreList { get; set; }
        public string GenreName { get; set; }
        [Display(Name = "All artists")]
        public MultiSelectList ArtistList { get; set; }
        //public string ArtistName { get; set; }
        public ArtistWithDetails CurrentArtist { get; set; }
        [Display(Name = "All tracks")]
        public MultiSelectList TrackList { get; set; }
    }
    public class AlbumBase : AlbumAdd
    {
        public int Id { get; set; }
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }
    }
    public class AlbumWithDetails : AlbumBase
    {
        public AlbumWithDetails()
        {
            Artists = new List<ArtistBase>();
            Tracks = new List<TrackBase>();
        }
        public ICollection<ArtistBase> Artists { get; set; }
        [Display(Name = "Number of artists on this album")]
        public int ArtistsCount { get; set; }
        public ICollection<TrackBase> Tracks { get; set; }
        [Display(Name = "Number of tracks on this album")]
        public int TracksCount { get; set; }
    }
    /////////////////////////////////////////////////////////////////////
    public class TrackAdd
    {
        public TrackAdd()
        {
        }
        public int Id { get; set; }
        [Required, StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = "Composer name(s)")]
        public string Composers { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        [StringLength(200)]
        [Display(Name = "Clerk who helps with album tasks")]
        public string Clerk { get; set; }
        [Display(Name = "Sample clip")]
        public HttpPostedFileBase ClipUpload { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        /*
        public byte[] Content { get; set; }
        [StringLength(200)]
        public string ContentType { get; set; }
        */
    }
    public class TrackAddForm
    {

        public TrackAddForm()
        {
        }
        public int Id { get; set; }
        [Required, StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = "Composer name(s)")]
        public string Composers { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        [StringLength(200)]
        [Display(Name = "Clerk who helps with album tasks")]
        public string Clerk { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Sample clip")]
        public string ClipUpload { get; set; }
        public string ClipUrl
        {
            get
            {
                return $"/clip/{Id}";
            }
        }
        [Display(Name = "Track genre")]
        public SelectList GenreList { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
    }
   
    public class TrackBase : TrackAdd
    {
        [Display(Name = "Track Genre")]
        public string Genre { get; set; }
        [Display(Name = "Number of albums with this track")]
        public int AlbumsCount { get; set; }
        public string ClipUrl
        {
            get
            {
                return $"/clip/{Id}";
            }
        }
    }
    public class TrackWithDetails : TrackBase
    {
        public TrackWithDetails()
        {
            Albums = new List<AlbumBase>();
        }
        public IEnumerable<AlbumBase> Albums { get; set; }
        [Display(Name = "Albums with this track")]
        public IEnumerable<string> AlbumNames { get; set; }
    }
    public class TrackEdit
    {
        public string Name { get; set; }
        public string Composer { get; set; }
        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }
        public IEnumerable<int> AlbumIds { get; set; }
    }
    public class TrackEditForm : TrackEdit
    {
        public int Id { get; set; }
        public SelectList GenreList { get; set; }
        public MultiSelectList AlbumList { get; set; }
        public IEnumerable<AlbumBase> CurrentAlbums { get; set; }
    }

    /////////////////////////////////////////////////////////////////////
    public class TrackClip
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
    /////////////////////////////////////////////////////////////////////
    public class GenreBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MediaItemAddForm
    {
        public int MediaItemId { get; set; }

        [Display(Name = "Artist information")]
        public string AtistInfo { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "MediaItem")]
        [DataType(DataType.Upload)]
        public string MediaItemUpload { get; set; }

        public int ArtistId { get; set; }
        public string ArtistDescription { get; set; }

    }

    public class MediaItemAdd
    {
        public int ArtistId { get; set; }

        [Required, StringLength(100)]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaItemUpload { get; set; }
    }
    public class MediaItemBase
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Unique identifier")]
        public string Caption { get; set; }

        [Display(Name = "Unique identifier")]
        public string StringId { get; set; }

        [Display(Name = "Added on date/time")]
        public DateTime TimeStamp { get; set; }

        public string ContentType { get; set; }

    }

    public class MediaItemContent
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

    public class ArtistWithMediaItemStringIds : ArtistBase
    {
        public ArtistWithMediaItemStringIds()
        {
            MediaItems = new List<MediaItemBase>();
        }
        public IEnumerable<MediaItemBase> MediaItems { get; set; }
    }
}

