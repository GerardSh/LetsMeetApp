namespace LetsMeetApp.GCommon
{
    public static class ErrorMessages
    {
        public static class Event
        {
            public const string UserNotFound = "User not found.";
            public const string CategoryDoesNotExist = "Selected category does not exist.";
            public const string PastEvent = "Event date must be at least one hour ahead of now.";
            public const string ImageUrlNotValid = "Image URL must be a valid http/https address.";
            public const string EventNotFoundOrNoPermission = "Event not found or you dont have permission to edit it.";
        }
    }
}
