using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Domain.Core.Events;

namespace Application.EventSourcedNormalizers.User
{
    public class UserHistory
    {
        public static IList<UserHistoryData> HistoryData { get; set; }

        public static IList<UserHistoryData> ToJavaScriptHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<UserHistoryData>();
            UserHistoryDeserializer(storedEvents);
            
            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<UserHistoryData>();
            var last = new UserHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new UserHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    IsAdmin = string.IsNullOrWhiteSpace(change.IsAdmin) || change.IsAdmin == last.IsAdmin
                        ? ""
                        : change.IsAdmin,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }
        
        private static void UserHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new UserHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "UserRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Id = values["Id"];
                        slot.Name = values["Name"];
                        slot.Email = values["Email"];
                        slot.Action = "Registered";
                        slot.IsAdmin = values["IsAdmin"];
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "UserUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Id = values["Id"];
                        slot.Name = values["Name"];
                        slot.Email = values["Email"];
                        slot.Action = "Updated";
                        slot.IsAdmin = values["IsAdmin"];
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "UserRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}