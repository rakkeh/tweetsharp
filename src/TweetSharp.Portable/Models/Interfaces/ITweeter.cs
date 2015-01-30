namespace TweetSharp
{
    public interface ITweeter : ITwitterModel
    {
        string ScreenName { get; }
        string ProfileImageUrl { get; }
    }
}