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
            public const string EventNotFoundNoPermissionOrExpired = "Event not found, has expired or you dont have permission to edit it.";
            public const string DoNotModify = "Please do not modify the page!";
        }
        public static class EventParticipation
        {
            public const string EventNotFound = "Event not found or deleted.";
            public const string CreatorCantLeaveEvent = "Creator cannot leave their own event.";
            public const string CreatorCantJoinEvent = "You are the creator of this event.";
            public const string CantLeavePastEvent = "Cannot leave past events.";
            public const string CantJoinPastEvent = "Cannot join past events.";
            public const string NotParticipating = "You are not participating in this event.";
            public const string AlreadyParticipating = "You are already participating in this event.";
        }

        public static class Controllers
        {
            public const string GeneralError = "Unexpected error occurred.";
        }
    }
}
