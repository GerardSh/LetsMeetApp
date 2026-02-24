namespace LetsMeetApp.GCommon
{
    public static class ValidationConstants
    {
        public static class ApplicationUser
        {
            public const int ApplicationUserFirstNameMinLength = 2;
            public const int ApplicationUserFirstNameMaxLength = 50;

            public const int ApplicationUserLastNameMinLength = 2;
            public const int ApplicationUserLastNameMaxLength = 50;

            public const int ApplicationUserCityMinLength = 2;
            public const int ApplicationUserCityMaxLength = 50;

            public const int ApplicationUserCountryMinLength = 3;
            public const int ApplicationUserCountryMaxLength = 100;

            public const int ApplicationUserBioMinLength = 20;
            public const int ApplicationUserBioMaxLength = 250;

            public const int ApplicationUserAvatarUrlMaxLength = 250;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;
        }

        public static class Event
        {
            public const int EventTitleMinLength = 3;
            public const int EventTitleMaxLength = 100;

            public const int EventDescriptionMinLength = 10;
            public const int EventDescriptionMaxLength = 500;

            public const int EventLocationMinLength = 20;
            public const int EventLocationMaxLength = 200;

            public const int EventCityMinLength = 2;
            public const int EventCityMaxLength = 50;

            public const int EventCountryMinLength = 3;
            public const int EventCountryMaxLength = 100;

            public const int EventImageUrlMaxLength = 250;

            public const string EventDateOnFormat = "yyyy-MM-dd";
        }
    }
}
