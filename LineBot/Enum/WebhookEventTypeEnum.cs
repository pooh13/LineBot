using System;
namespace LineBot.Enum
{
    public static class WebhookEventTypeEnum
    {
        public const string Message = "message";
        public const string Unsend = "unsend";
        public const string Follow = "follow";
        public const string Unfollow = "unfollow";
        public const string Join = "join";
        public const string Leave = "leave";
        public const string MemberJoined = "memberjoin";
        public const string MemberLeft = "memberleft";
        public const string Postback = "postback";
        public const string VideoPlayComplete = "videoplaycomplete";
    }
}

