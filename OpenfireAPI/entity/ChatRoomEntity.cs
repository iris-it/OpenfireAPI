using System;
using System.Collections.Generic;

namespace OpenfireAPI.entity
{
    public class ChatRoomEntity
    {
        public string roomName { get; set; }
        public string description { get; set; }
        public string password { get; set; }
        public string subject { get; set; }
        public string naturalName { get; set; }

        public int maxUsers { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }

        public bool persistent { get; set; }
        public bool publicRoom { get; set; }
        public bool registrationEnabled { get; set; }
        public bool canAnyoneDiscoverJid { get; set; }
        public bool canOccupantsChangeSubject { get; set; }
        public bool canOccupantsInvite { get; set; }
        public bool canChangeNickname { get; set; }
        public bool logEnabled { get; set; }
        public bool loginRestrictedToNickname { get; set; }
        public bool membersOnly { get; set; }
        public bool moderated { get; set; }

        public broadcastPresenceRoleEntities broadcastPresenceRoles { get; set; }

        public OwnerEntities owners { get; set; }

        public AdminEntities admins { get; set; }

        public MemberEntities members { get; set; }

        public OutcastEntities outcasts { get; set; }


        public string Tostring()
        {
            return "RoomName: " + roomName + ", Description: " + description + "\n";
        }
    }

    public class broadcastPresenceRoleEntities
    {
        public List<String> broadcastPresenceRole { get; set; }
    }

    public class OwnerEntities
    {
        public List<String> owner { get; set; }
    }

    public class AdminEntities
    {
        public List<String> admin { get; set; }
    }

    public class MemberEntities
    {
        public List<String> member { get; set; }
    }

    public class OutcastEntities
    {
        public List<String> outcast { get; set; }
    }
}