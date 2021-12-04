using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.WebUI.ZoomAPI.Abstract
{
    public interface IZoomMeetingsClient
    {
        ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30,int pageNumber = 1)
        Meeting CreateMeeting(string userId, Meeting meeting);
        Meeting GetMeeting(string meetingId);
        bool UpdateMeeting(string meetingId, Meeting meeting);
        bool DeleteMeeting(string meetingId, string occurrenceId = null);
        bool EndMeeting(string meetingId);
        ListMeetingRegistrants GetMeetingTegistrants(string meetingId, string status = "approved", string occurrenceId = null, int pageSize = 30, int pageNumber = 1);
        MeetingRegistrant CreateMeetingRegistrant(string meetingId, CreateMeetingRegistrants meetingRegistrants, string occurrenceIds = null);
        bool UpdateMeetingRegistrant(string meetingId, List<UpdateMeetingRegistrant> registrants, string status, string occurrenceId = null);
    }
}