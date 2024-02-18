namespace SeminarHub.Data
{
    public static class DataConstants
    {
        //Seminar constants
        public const int SeminarTopicMinLenght = 3;
        public const int SeminarTopicMaxLenght = 100;

        public const int SeminarLecturerMinLenght = 5;
        public const int SeminarLecturerMaxLenght = 60;

        public const int SeminarDetailsMinLenght = 10;
        public const int SeminarDetailsMaxLenght = 500;

        public const string SeminarDateFormat = "dd/MM/yyyy HH:mm";

        public const int SeminarDurationMinValue = 30;
        public const int SeminarDuratuinMaxValue = 180;

        //Category constants
        public const int CategoryNameMinLenght = 3;
        public const int CategoryNameMaxLenght = 50;


        //Error Messages
        public const string RequiredTypeErrorMessage = "{0} is required";
        public const string StringLenghtErrorMessage = "{0} lenght must be between {2} and {1}";
        public const string DurationOutOfRangeError = "Duration must be between {1} and {2}";
    }
}
