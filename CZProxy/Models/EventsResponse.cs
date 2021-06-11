using System.Collections.Generic;

namespace CZProxy.Models
{
        public class PeriodCounts
    {
        public int Upcoming { get; set; }
        public int Past { get; set; }
    }

    public class Time
    {
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class ParticipationFormat
    {
        public bool Online { get; set; }
        public bool Indoor { get; set; }
        public string Location { get; set; }
        public string OnlineLabel { get; set; }
    }

    public class Images
    {
        public string L { get; set; }
        public string M { get; set; }
        public string S { get; set; }
    }

    public class Branding
    {
        public string Type { get; set; }
        public Images Images { get; set; }
        public string Class { get; set; }
    }

    public class EventStatus
    {
        public string Class { get; set; }
        public string Text { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Avatar { get; set; }
    }

    public class Speakers
    {
        public IList<Photo> Photos { get; set; }
        public int Count { get; set; }
    }

    public class Community
    {
        public string Title { get; set; }
        public string Logo { get; set; }
    }

    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Dates { get; set; }
        public Time Time { get; set; }
        public bool IsPast { get; set; }
        public string Language { get; set; }
        public IList<string> Languages { get; set; }
        public string Size { get; set; }
        public ParticipationFormat ParticipationFormat { get; set; }
        public Branding Branding { get; set; }
        public EventStatus EventStatus { get; set; }
        public Speakers Speakers { get; set; }
        public bool InCalendar { get; set; }
        public bool IsCalendar { get; set; }
        public string Location { get; set; }
        public bool IsQrCode { get; set; }
        public Community Community { get; set; }
    }

    public class EventsResponse
    {
        public int Total { get; set; }
        public int Took { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        public string Period { get; set; }
        public PeriodCounts PeriodCounts { get; set; }
        public IList<Event> Events { get; set; }
        public string ErrorMessage { get; set; }

        public bool HasPreviousPage => Start > 0;
        public bool HasNextPage => Total > 0 && Total % Limit + 1 > Start;
    }
}