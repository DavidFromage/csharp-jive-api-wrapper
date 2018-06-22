using System;

namespace CheezeIT.JiveAPI.Wrapper
{
    public class EndPoints
    {
        // Contents
        public static String AllContents = "/contents";
        public static String ContentById = "/contents/{0}";
        public static String ContentsAttachments = "/attachments/contents/{0}";
        // attachements

        // Persons/people
        public static String PersonByIdWithPhotos = "/people/username/{0}?fields=photos";
        public static String TemporaryProfileImage = "/profileImages/temporary";
        public static String PersonByIdProfileImages = "/people/{0}/images/";
        public static String PersonByUsernameProfileImages = "/people/{0}/images/";

        // Places
        public static String Places = "/places";
        public static String PlaceById = "/places/{0}";
        // Statics
        public static String StaticsByPlaceID = "/statics/{0}";


    }
}