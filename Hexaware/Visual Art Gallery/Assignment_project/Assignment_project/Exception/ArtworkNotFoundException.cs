using System;

namespace VirtualArtGallery.Exceptions
{
    public class ArtworkNotFoundException : ApplicationException
    {
        public ArtworkNotFoundException(string message) : base(message)
        {
        }
    }
}
