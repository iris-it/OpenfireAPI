using OpenfireAPI.entity;
using System.Collections.Generic;
using RestSharp.Deserializers;
using OpenfireAPI.util;

namespace OpenfireAPI
{
    public class OpenfireApiClient
    {
        public OpenfireClient Client { get; private set; }
        public JsonDeserializer Deserial { get; private set; }

        public OpenfireApiClient(string url, int port, OpenfireAuthenticator authenticator)
        {
            Client = new OpenfireClient(url, port, authenticator);
            Deserial = new JsonDeserializer();
        }

        /*User related APIs*/
        public UserEntities getUsers()
        {
            var response = Client.get("users", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<UserEntities>(response) : null;
        }

        public UserEntity getUser(string username)
        {
            var response = Client.get("users/" + username, new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<UserEntity>(response) : null;
        }

        public bool createUser(UserEntity userEntity)
        {
            return Client.isStatusCodeOK(Client.post("users", userEntity, new Dictionary<string, string>()));
        }

        public bool deleteUser(string username)
        {
            return Client.isStatusCodeOK(Client.delete("users/" + username, null, new Dictionary<string, string>()));
        }

        public bool updateUser(string username, UserEntity userEntity)
        {
            return Client.isStatusCodeOK(Client.put("users/" + username, userEntity, new Dictionary<string, string>()));
        }

        public UserGroupsEntity getUserGroups(string username)
        {
            var response = Client.get("users/" + username + "/groups", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<UserGroupsEntity>(response) : null;
        }

        public bool addUserToGroups(string username, UserGroupsEntity groups)
        {
            return Client.isStatusCodeOK(Client.post("users/" + username + "/groups", groups,
                new Dictionary<string, string>()));
        }

        public bool addUserToGroup(string username, string group)
        {
            return Client.isStatusCodeOK(Client.post("users/" + username + "/groups/" + group, null,
                new Dictionary<string, string>()));
        }

        public bool deleteUserFromGroups(string username, UserGroupsEntity groups)
        {
            return Client.isStatusCodeOK(Client.delete("users/" + username + "/groups", groups,
                new Dictionary<string, string>()));
        }

        public bool deleteUserFromGroup(string username, string group)
        {
            return Client.isStatusCodeOK(Client.delete("users/" + username + "/groups/" + group, null,
                new Dictionary<string, string>()));
        }

        public bool lockoutUser(string username)
        {
            return Client.isStatusCodeOK(Client.post("lockouts/" + username, null, new Dictionary<string, string>()));
        }

        public bool unlockUser(string username)
        {
            return Client.isStatusCodeOK(Client.delete("lockouts/" + username, null, new Dictionary<string, string>()));
        }

        public RosterEntities getRoster(string username)
        {
            var response = Client.get("users/" + username + "/roster", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<RosterEntities>(response) : null;
        }

        public bool addRosterEntry(string username, RosterEntity rosterEntry)
        {
            return Client.isStatusCodeOK(Client.post("users/" + username + "/roster", rosterEntry,
                new Dictionary<string, string>()));
        }

        public bool deleteRosterEntry(string username, string jid)
        {
            return Client.isStatusCodeOK(Client.delete("users/" + username + "/roster/" + jid, null,
                new Dictionary<string, string>()));
        }

        public bool updateRosterEntry(string username, RosterEntity rosterEntry)
        {
            return Client.isStatusCodeOK(Client.put("users/" + username + "/roster", rosterEntry,
                new Dictionary<string, string>()));
        }

        public SystemProperties getSystemProperties()
        {
            var response = Client.get("system/properties", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<SystemProperties>(response) : null;
        }

        public SystemProperty getSystemProperty(string propertyName)
        {
            var response = Client.get("system/properties/" + propertyName, new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<SystemProperty>(response) : null;
        }

        public bool createSystemProperty(SystemProperty systemProperty)
        {
            return Client.isStatusCodeOK(Client.post("system/properties", systemProperty,
                new Dictionary<string, string>()));
        }

        public bool updateSystemProperty(SystemProperty systemProperty)
        {
            return Client.isStatusCodeOK(Client.put("system/properties/" + systemProperty.key, systemProperty,
                new Dictionary<string, string>()));
        }

        public bool deleteSystemProperty(string propertyName)
        {
            return Client.isStatusCodeOK(Client.delete("system/properties/" + propertyName, null,
                new Dictionary<string, string>()));
        }

        public GroupEntities getGroups()
        {
            var response = Client.get("groups", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<GroupEntities>(response) : null;
        }

        public GroupEntity getGroup(string groupName)
        {
            var response = Client.get("groups/" + groupName, new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<GroupEntity>(response) : null;
        }

        public bool createGroup(GroupEntity groupEntity)
        {
            return Client.isStatusCodeOK(Client.post("groups", groupEntity, new Dictionary<string, string>()));
        }

        public bool deleteGroup(string groupName)
        {
            return Client.isStatusCodeOK(Client.delete("groups/" + groupName, null, new Dictionary<string, string>()));
        }

        public bool updateGroup(GroupEntity groupEntity)
        {
            return Client.isStatusCodeOK(Client.put("groups/" + groupEntity.name, groupEntity,
                new Dictionary<string, string>()));
        }

        /**
	     * Gets the chat rooms.
         */
        public ChatRoomEntities getChatRooms()
        {
            var response = Client.get("chatrooms", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<ChatRoomEntities>(response) : null;
        }


        /**
         * Gets the chat room.
         */
        public ChatRoomEntity getChatRoom(string roomName)
        {
            var response = Client.get("chatrooms/" + roomName, new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<ChatRoomEntity>(response) : null;
        }

        /**
         * Creates the chat room.
         */
        public bool createChatRoom(ChatRoomEntity chatRoom)
        {
            return Client.isStatusCodeOK(Client.post("chatrooms", chatRoom, new Dictionary<string, string>()));
        }

        /**
         * Update chat room.
         */
        public bool updateChatRoom(ChatRoomEntity chatRoom)
        {
            return Client.isStatusCodeOK(Client.put("chatrooms/" + chatRoom.roomName, chatRoom,
                new Dictionary<string, string>()));
        }

        /**
         * Delete chat room.
         */
        public bool deleteChatRoom(string roomName)
        {
            return Client.isStatusCodeOK(Client.delete("chatrooms/" + roomName, null,
                new Dictionary<string, string>()));
        }

        /**
         * Gets the chat room participants.
         */
        public ParticipantEntities getChatRoomParticipants(string roomName)
        {
            var response = Client.get("chatrooms/" + roomName + "/participants", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<ParticipantEntities>(response) : null;
        }

        /**
         * Gets the chat room participants.
         */
        public OccupantEntities getChatRoomOccupants(string roomName)
        {
            var response = Client.get("chatrooms/" + roomName + "/occupants", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<OccupantEntities>(response) : null;
        }

        /**
         * Adds the owner.
         */
        public bool addOwner(string roomName, string jid)
        {
            return Client.isStatusCodeOK(Client.post("chatrooms/" + roomName + "/owners/" + jid, null,
                new Dictionary<string, string>()));
        }

        /**
         * Adds the admin.
         */
        public bool addAdmin(string roomName, string jid)
        {
            return Client.isStatusCodeOK(Client.post("chatrooms/" + roomName + "/admins/" + jid, null,
                new Dictionary<string, string>()));
        }

        /**
         * Adds the member.
         */
        public bool addMember(string roomName, string jid)
        {
            return Client.isStatusCodeOK(Client.post("chatrooms/" + roomName + "/members/" + jid, null,
                new Dictionary<string, string>()));
        }

        /**
         * Adds the outcast.
         */
        public bool addOutcast(string roomName, string jid)
        {
            return Client.isStatusCodeOK(Client.post("chatrooms/" + roomName + "/outcasts/" + jid, null,
                new Dictionary<string, string>()));
        }


        //TODO: /system/statistics/sessions
        //TODO: Chatroom

        public SessionEntities getSessions()
        {
            var response = Client.get("sessions", new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<SessionEntities>(response) : null;
        }

        public SessionEntities getSessions(string username)
        {
            var response = Client.get("sessions/" + username, new Dictionary<string, string>());
            return Client.isStatusCodeOK(response) ? Deserial.Deserialize<SessionEntities>(response) : null;
        }

        public bool closeSessions(string username)
        {
            return Client.isStatusCodeOK(Client.delete("sessions/" + username, null, new Dictionary<string, string>()));
        }

        public bool broadcastMsg(MessageEntity messageEntity)
        {
            return Client.isStatusCodeOK(Client.post("messages/users", messageEntity,
                new Dictionary<string, string>()));
        }
    }
}