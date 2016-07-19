using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment_8
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithDetails>();
            Mapper.CreateMap<Controllers.ArtistAddForm, Models.Artist>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithMediaItemStringIds>();
            Mapper.CreateMap<Controllers.ArtistBase, Controllers.ArtistWithMediaItemStringIds>();

            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumWithDetails>();
            Mapper.CreateMap<Controllers.AlbumAddForm, Models.Album>();

            Mapper.CreateMap<Models.Genre, Controllers.GenreBase>();
            
            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Models.Track, Controllers.TrackWithDetails>();
            Mapper.CreateMap<Models.Track, Controllers.TrackClip>();

            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Controllers.TrackAddForm, Models.Track>();
            Mapper.CreateMap<Controllers.TrackAddForm, Controllers.TrackAdd>();
            Mapper.CreateMap<Controllers.TrackBase, Controllers.TrackEditForm>();
            Mapper.CreateMap<Controllers.TrackWithDetails, Controllers.TrackEditForm>();

            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemBase>();
            Mapper.CreateMap<Controllers.MediaItemAddForm, Models.MediaItem>();
            Mapper.CreateMap<Controllers.MediaItemAddForm, Controllers.MediaItemAdd>();
            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemContent>();

            /*
            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
            Mapper.CreateMap<Models.Vehicle, Controllers.VehicleBase>();
            Mapper.CreateMap<Models.Vehicle, Controllers.VehiclePhoto>();
            Mapper.CreateMap<Controllers.VehicleAdd, Models.Vehicle>();
            */
            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // AutoMapper create map statements

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            // Add more below...





#pragma warning restore CS0618
        }
    }
}