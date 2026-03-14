namespace LetsMeetApp.GCommon
{
    public static class SuccessMessages
    {
        public static class Event
        {
            public const string CreateSuccess = "Event created successfully and you are now the organizer.";
            public const string EditSuccess = "Event details updated successfully.";
            public const string DeleteSuccess = "Event deleted successfully.";
        }

        public static class EventParticipation
        {
            public const string JoinSuccess = "Your participation has been confirmed.";
            public const string LeaveSuccess = "You have left the event.";
        }
    }
}
